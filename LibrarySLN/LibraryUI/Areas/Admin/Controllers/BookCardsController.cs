﻿using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryUI.Areas.Admin.Controllers
{
    public class BookCardsController : Controller
    {
        public Librarian _librarian;
        
        public BookCardsController() : 
            this(new SqlStorageProvider(ConfigurationManager.ConnectionStrings["TestDB"].ToString()))
        {

        }
        
        public BookCardsController(IStorageProvider sqlProvider)
        {
            _librarian = new Librarian(sqlProvider);
        }
        
        public ActionResult Index()
        {
            IEnumerable<BookCard> bookCards = _librarian.GetAllBookCards();
            IEnumerable<BookCardViewModel> bookCardViewModel = bookCards.Select(b => new BookCardViewModel
            {
                Id = b.Id,
                Title = b.Title
            });

            return View(bookCardViewModel);
        }
        
        public ActionResult Details(Guid id)
        {
            BookCard bookCard = _librarian.GetBookCardById(id);
            BookCardViewModel bookCardViewModel = new BookCardViewModel
            {
                Id = bookCard.Id,
                Title = bookCard.Title
            };

            return View(bookCardViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookCardViewModel bookCardViewModel)
        {
            try
            {
                BookCard bookCard = new BookCard { Title = bookCardViewModel.Title };
                _librarian.AddBook(bookCard);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(bookCardViewModel);
            }
        }
        
        public ActionResult Edit(Guid id)
        {
            BookCard bookCard = _librarian.GetBookCardById(id);
            BookCardViewModel bookCardViewModel = new BookCardViewModel
            {
                Id = bookCard.Id,
                Title = bookCard.Title
            };

            return View(bookCardViewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(Guid idToEdit, BookCardViewModel bookCardViewModel)
        {
            try
            {
                BookCard bookCard = new BookCard
                {
                    Id = bookCardViewModel.Id,
                    Title = bookCardViewModel.Title.Trim()
                };

                bookCardViewModel.registerResult =
                    _librarian.UpdateBookCard(idToEdit, bookCard);
                if (!(bool)bookCardViewModel.registerResult)
                {
                    return View(bookCardViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(bookCardViewModel);
            }
        }
        
        public ActionResult Delete(Guid id)
        {
            BookCard bookCard = _librarian.GetBookCardById(id);
            BookCardViewModel bookCardViewModel = new BookCardViewModel
            {
                Id = bookCard.Id,
                Title = bookCard.Title
            };

            return View(bookCardViewModel);
        }
        
        [HttpPost]
        public ActionResult Delete(BookCardViewModel bookCardViewModel)
        {
            try
            {
                bookCardViewModel.registerResult = _librarian.RemoveBookCard(bookCardViewModel.Id);
                if (!(bool)bookCardViewModel.registerResult)
                {
                    return View(bookCardViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View(bookCardViewModel);
            }
        }
    }
}
