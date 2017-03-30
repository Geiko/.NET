using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace LibraryUI.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        public Librarian _librarian;
        
        public UsersController() : 
            this(new SqlStorageProvider(ConfigurationManager.ConnectionStrings["TestDB"].ToString()))
        {

        }
        
        public UsersController(IStorageProvider sqlProvider)
        {
            _librarian = new Librarian(sqlProvider);
        }
        
        public ActionResult Index()
        {
            var users = _librarian.GetAllUsers();
            IEnumerable<UserViewModel> userViewModel = 
                    users.Select(u => new UserViewModel() { Email = u.Email });
            return View(userViewModel);
        }
        
        public ActionResult Details(string email)
        {                       
            var userRecords = _librarian.GetBookRecords(email.Trim())
                    .Select(r => new UserRecordsViewModel
                    {
                        BookTitle = _librarian.GetBookCardById(r.BookCardId).Title,
                        FirstAuthor = _librarian.GetAuthorNamesByBookId(r.BookCardId)
                                        .FirstOrDefault(),
                        BookId = r.BookCardId,
                        GetoutTime = r.GetoutTime,
                        ReturnTime = r.ReturnTime
                    }).OrderBy(r => r.GetoutTime).ToList();
            ViewBag.userEmail = email;            
            return View(userRecords);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            try
            {
                if (string.IsNullOrEmpty(userViewModel.Email))
                {
                    return View(userViewModel);
                }
                bool result = _librarian.AddUser(userViewModel.Email.Trim());
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
                //TODO: add logging of exception
            }
        }
        
        public ActionResult Edit(string email)
        {
            UserViewModel userViewModel = new UserViewModel { Email = email };
            return View(userViewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(string OldEmail, UserViewModel userViewModel)
        {
            try
            {
                userViewModel.registerResult = 
                        _librarian.UpdateUser(OldEmail.Trim(), userViewModel.Email.Trim());
                if (!(bool)userViewModel.registerResult)
                {
                    return View(userViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
                //TODO: add logging of exception
            }
        }
        
        public ActionResult Delete(string email)
        {
            UserViewModel userViewModel = new UserViewModel { Email = email };
            return View(userViewModel);
        }
        
        [HttpPost]
        public ActionResult Delete(string email, UserViewModel userViewModel)
        {
            try
            {
                userViewModel.registerResult = _librarian.RemoveUser(userViewModel.Email.Trim());
                if (!(bool)userViewModel.registerResult)
                {
                    return View(userViewModel);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
                //TODO: add logging of exception
            }
        }
    }
}
