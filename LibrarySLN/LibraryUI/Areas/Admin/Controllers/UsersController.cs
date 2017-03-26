using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
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
            IEnumerable<Record> records = _librarian.GetBookRecords(email.Trim());

            IEnumerable<string> strRecords = records.Select(r =>
                    string.Format($"{r.BookCardId} / {r.GetoutTime} / {r.ReturnTime}"));

            UserViewModel userViewModel = new UserViewModel
            {
                Email = email,
                Records = new SelectList(strRecords)
            };

            return View(userViewModel);
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
                bool result = _librarian.AddUser(userViewModel.Email.Trim());
                return RedirectToAction("Index");
            }
            catch
            {
                return View(userViewModel);
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
                ViewBag.Error = ex.Message;
                return View(userViewModel);
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
                return View(userViewModel);
            }
        }
    }
}
