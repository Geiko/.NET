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

        public ActionResult Index(int? page, string filterType, string sortType)
        {
            filterType = getSelectedFilter(filterType, "filterParameter");
            sortType = getSelectedFilter(sortType, "sortParameter");
            filterType = filterType ?? "all";
            sortType = sortType ?? "byTytle";

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
            BookCardViewModelPaged bcvm = new BookCardViewModelPaged
            {
                BookCards = bookCardsViewModel.ToPagedList(pageNumber, PAGE_SIZE),
                FilterType = filterType,
                SortType = sortType
            };

            return View(bcvm);
        }
        
        private string getSelectedFilter(string category, string categoryParameter)
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

            return category;
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
                        _librarian.GetAuthorsByBookId(b.Id).FirstOrDefault().Name)
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
                userViewModel.registerResult = _librarian.AddUser(userViewModel.Email);
                if (!(bool)userViewModel.registerResult)
                {
                    return View(userViewModel);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(userViewModel);
            }
        }

    }
}
