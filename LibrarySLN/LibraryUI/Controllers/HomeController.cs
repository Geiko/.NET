using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryBL.UserModels;
using LibraryUI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
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

        public ActionResult Index(int? page, string showType)
        {
            showType = showType ?? "all";
            IEnumerable<BookCard> bookCards = null;
            if (showType.Equals("all"))
            {
                bookCards = _librarian.GetAllBookCards();
            }
            else if (showType.Equals("available"))
            {
                bookCards = _librarian.GetAvailableBookCards();
            }
            else if (showType.Equals("taken"))
            {
                bookCards = _librarian.GetTakenBookCards();
            }

            List<BookCardViewModel> bookCardsViewModel =
                    bookCards.Select(b => new BookCardViewModel()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        isAvailable = _librarian.isBookAvailable(b.Id)
                    }).ToList();
            int pageNumber = (page ?? 1);
            BookCardViewModel bcvm = new BookCardViewModel
            {
                BookCards = bookCardsViewModel.ToPagedList(pageNumber, PAGE_SIZE)
            };

            return View(bcvm);
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
