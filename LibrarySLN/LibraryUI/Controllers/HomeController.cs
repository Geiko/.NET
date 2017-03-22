using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryBL.UserModels;
using LibraryUI.Models;
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


        public HomeController() : 
            this(new SqlStorageProvider(ConfigurationManager.ConnectionStrings["TestDB"].ToString()))
        {

        }


        public HomeController(IStorageProvider sqlProvider)
        {
            _librarian = new Librarian(sqlProvider);
        }




        // GET: Home
        public ActionResult Index()
        {
            var bookCards = _librarian.GetAllBookCards();
            List<BookCardViewModel> bookCardsViewModel = bookCards.Select(
                    b => new BookCardViewModel() { Id = b.Id, Title = b.Title}).ToList();
            return View(bookCardsViewModel);
        }




        //// GET: Home/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Home/Create
        //[HttpPost]
        //public ActionResult Create(BookCardViewModel bookCardViewModel)
        //{
        //    try
        //    {
        //        BookCard bookCard = new BookCard { Title = bookCardViewModel.Title };
        //        _librarian.AddBook(bookCard);

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(bookCardViewModel);
        //    }
        //}





        // GET: Home/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            try
            {
                userViewModel.registerResult = _librarian.AddUser(userViewModel.Email);
                if(!(bool)userViewModel.registerResult)
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
