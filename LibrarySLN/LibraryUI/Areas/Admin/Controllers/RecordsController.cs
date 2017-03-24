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
using System.Net;
using System.Net.Mail;
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
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }
        
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
                    // TODO: use JS to make button unable if book unable
                }

                BookCard bookCard = _librarian.GetBookCardById(id);
                var bookAuthors = _librarian.GetAuthorsByBookId(id).Select(a => a.Name);
                string authors = string.Join(", ", bookAuthors.ToArray());
                string content = $"{authors} \"{bookCard.Title}\"";
                SendEmailToUser(tookBookUser, content);

                return RedirectToAction("Index", "BookCards");
            }
            catch
            {
                throw;
            }
        }

        private void SendEmailToUser(string tookBookUserEmail, string content)
        {
            MailAddress from = new MailAddress("k.i.geiko@gmail.com", "The Library");
            MailAddress to = new MailAddress(tookBookUserEmail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "You took the following book in our library: ";
            m.Body = content;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //Password is needed to execute.
            smtp.Credentials = new NetworkCredential("k.i.geiko@gmail.com", "********");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        
        public ActionResult Edit(Guid id)
        {
            return View();
        }
        
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
        
        public ActionResult Delete(int id)
        {
            return View();
        }
        
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
