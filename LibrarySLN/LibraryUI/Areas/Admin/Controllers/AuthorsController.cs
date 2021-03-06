﻿using LibraryBL.BookModels;
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
    public class AuthorsController : Controller
    {
        public Librarian _librarian;
        
        public AuthorsController() : 
            this(new SqlStorageProvider(ConfigurationManager.ConnectionStrings["TestDB"].ToString()))
        {

        }
        
        public AuthorsController(IStorageProvider sqlProvider)
        {
            _librarian = new Librarian(sqlProvider);
        }
        
        public ActionResult Index()
        {
            var authors = _librarian.GetAllAuthors();
            IEnumerable<AuthorViewModel> authorViewModel = authors.Select(a => new AuthorViewModel
            {
                Id = a.Id,
                Name = a.Name
            });

            return View(authorViewModel);
        }
        
        public ActionResult Details(Guid authorId)
        {
            Author author = _librarian.GetAuthorById(authorId);
            AuthorViewModel authorViewModel = new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name,
                AuthorBooks = new SelectList(
                        _librarian.GetBookCardsByAuthorId(authorId).Select(a => a.Title).ToList())
            };

            return View(authorViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(AuthorViewModel authorViewModel)
        {
            try
            {
                if (string.IsNullOrEmpty(authorViewModel.Name))
                {
                    return View(authorViewModel);
                }

                authorViewModel.registerResult = _librarian.AddAuthor(new Author(authorViewModel.Name.Trim()) ); 
                if (!(bool)authorViewModel.registerResult)
                {
                    return View(authorViewModel);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw;
                //TODO: add logging of exception
            }
        }
        
        public ActionResult Edit(Guid id)
        {
            Author author = _librarian.GetAuthorById(id);
            AuthorViewModel authorViewModel = new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name
            };

            return View(authorViewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(Guid idToEdit, AuthorViewModel authorViewModel)
        {
            try
            {
                Author author = new Author
                {
                    Id = authorViewModel.Id,
                    Name = authorViewModel.Name.Trim()
                };

                authorViewModel.registerResult =
                    _librarian.UpdateAuthor(idToEdit, author);
                if (!(bool)authorViewModel.registerResult)
                {
                    return View(authorViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
                //TODO: add logging of exception
            }
        }
        
        public ActionResult Delete(Guid id)
        {
            Author author = _librarian.GetAuthorById(id);
            AuthorViewModel authorViewModel = new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name
            };

            return View(authorViewModel);
        }
        
        [HttpPost]
        public ActionResult Delete(AuthorViewModel authorViewModel)
        {
            try
            {
                authorViewModel.registerResult = _librarian.RemoveAuthor(authorViewModel.Id);
                if (!(bool)authorViewModel.registerResult)
                {
                    return View(authorViewModel);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw;
                //TODO: add logging of exception
            }
        }
    }
}
