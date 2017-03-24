using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryBL.UserModels;
using LibraryUI.Areas.Admin.Models;
using LibraryUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryUI.Areas.Admin.Controllers
{
    public class RecordsController : Controller
    {
        public Librarian _librarian;

        public RecordsController() : 
            this(new SqlStorageProvider(ConfigurationManager.ConnectionStrings["TestDB"].ToString()))
        {

        }

        public RecordsController(IStorageProvider sqlProvider)
        {
            _librarian = new Librarian(sqlProvider);
        }

        // GET: Admin/Records
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Records/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Records/Create
        public ActionResult Create(Guid id)
        {
            List<string> allUsers = _librarian.GetAllUsers().Select(u => u.Email).ToList();
            BookCard bookCard = _librarian.GetBookCardById(id);

            RecordViewModel recordViewModel = new RecordViewModel
            {
                AllUsers = new SelectList(allUsers),
                BookCard = bookCard,
                isBookAvailable = _librarian.isBookAvailable(id)
            };

            return View(recordViewModel);
        }

        // POST: Admin/Records/Create
        [HttpPost]
        public ActionResult Create(Guid id, string tookBookUser)
        {
            try
            {
                bool result = _librarian.GetoutBook(id, tookBookUser);

                ViewBag.RecordResult = "The book has been got out successfully.";
                if (!result)
                {
                    ViewBag.RecordResult = 
                        "This can't be executed. The book has been got out to other reader already.";
                    // TODO: js make button unable if book unable
                }

                return RedirectToAction("Index", "BookCards");
            }
            catch
            {
                throw;
            }
        }

        // GET: Admin/Records/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Admin/Records/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Records/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Records/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
