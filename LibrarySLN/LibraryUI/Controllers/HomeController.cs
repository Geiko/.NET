using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryUI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace LibraryUI.Controllers
{
    public class HomeController : Controller
    {
        public Librarian _librarian;
        private const int PAGE_SIZE = 5;

        public HomeController() :
            this(new SqlStorageProvider(ConfigurationManager.ConnectionStrings["TestDB"].ToString()))
        {

        }

        public HomeController(IStorageProvider sqlProvider)
        {
            _librarian = new Librarian(sqlProvider);
        }

        public ActionResult Index(int? page, string filterType, string sortType, bool? registerUserResult)
        {
            filterType = getSelectedFilter(filterType, "filterParameter", "all");
            sortType = getSelectedFilter(sortType, "sortParameter", "byTytle");
            IEnumerable<BookCard> bookCards = filterBookCards(filterType);
            IEnumerable<BookCardViewModel> bookCardsViewModel = bookCards.Select(b =>
                    new BookCardViewModel()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        BookAuthors = new SelectList(
                                _librarian.GetAuthorsByBookId(b.Id).Select(a => a.Name).ToList()),
                        isAvailable = _librarian.isBookAvailable(b.Id)
                    });

            bookCardsViewModel = sortBookCards(bookCardsViewModel, sortType);
            int pageNumber = (page ?? 1);
            bool result = registerUserResult ?? false;
            BookCardViewModelPaged bcvm = new BookCardViewModelPaged
            {
                BookCards = bookCardsViewModel.ToPagedList(pageNumber, PAGE_SIZE),
                FilterType = filterType,
                SortType = sortType,
                registerResult = result
            };

            return View(bcvm);
            // TODO: Implement Basket for Books 
        }
        
        private string getSelectedFilter(string category, string categoryParameter, string defaultValue)
        {
            if (!string.IsNullOrEmpty(category))
            {
                TempData[categoryParameter] = category;
                TempData.Keep();
            }
            else
            {
                if (TempData[categoryParameter] != null)
                {
                    category = TempData.Peek(categoryParameter).ToString();
                    TempData.Keep();
                }
            }
            
            return category ?? defaultValue;
        }
        
        private IEnumerable<BookCardViewModel> sortBookCards(
            IEnumerable<BookCardViewModel> bookCardsViewModel, string sortType)
        {
            if (sortType.Equals("byTytle"))
            {
                return bookCardsViewModel.OrderBy(b => b.Title);
            }
            else if (sortType.Equals("byAuthor"))
            {
                return bookCardsViewModel.OrderBy(b =>
                        _librarian.GetAuthorNamesByBookId(b.Id).FirstOrDefault())
                        .ThenBy(b => b.Title);
            }

            throw new ArgumentOutOfRangeException($"SortType isn't correct - {sortType}");
        }
        
        private IEnumerable<BookCard> filterBookCards(string filterType)
        {
            if (filterType.Equals("all"))
            {
                return _librarian.GetAllBookCards();
            }
            else if (filterType.Equals("available"))
            {
                return _librarian.GetAvailableBookCards();
            }
            else if (filterType.Equals("taken"))
            {
                return _librarian.GetTakenBookCards();
            }

            throw new ArgumentOutOfRangeException($"FilterType isn't correct - {filterType}");
        }
        
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            try
            {
                bool result = _librarian.AddUser(userViewModel.Email);
                       
                return RedirectToAction("Index", new { registerUserResult = result as bool? });
            }
            catch
            {
                return View(userViewModel);
            }
        }


        public ActionResult Cart()
        {
            return View();
        }
    }
}
