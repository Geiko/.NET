using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using LibraryUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
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
            IEnumerable<BookCardViewModel> bookCardsViewModel = bookCards.Select(b => 
            new BookCardViewModel
            {
                Id = b.Id,
                Title = b.Title,
                isAvailable = _librarian.isBookAvailable(b.Id),
                BookAuthors = new SelectList(
                        _librarian.GetAuthorsByBookId(b.Id).Select(a=> a.Name).ToList()) 
            });

            return View(bookCardsViewModel);
        }
        
        public ActionResult Details(Guid id)
        {
            BookCard bookCard = _librarian.GetBookCardById(id);
            StringBuilder sb = new StringBuilder();
            foreach (var n in _librarian.GetAuthorsByBookId(bookCard.Id))
            {
                sb.Append(n.Name.Trim()).Append(", ");
            }
            ViewBag.AuthorNames = sb.ToString().Trim().TrimEnd(',');
            ViewBag.IsAvailable = _librarian.isBookAvailable(bookCard.Id);
            ViewBag.BookCardId = bookCard.Id;
            ViewBag.BookCardTitle = bookCard.Title;
            var bookRecords = _librarian.GetBookRecords(id).Select(r => 
                    new BookCardRecordsViewModel
                    {
                        UserEmail = r.UserEmail,
                        GetoutTime = r.GetoutTime,
                        ReturnTime = r.ReturnTime
                    }).OrderBy(r => r.GetoutTime).ToList();

            return View(bookRecords);
        }
        
        public ActionResult Create()
        {
            IEnumerable<Author> allAuthors = _librarian.GetAllAuthors();
            BookCardViewModel bookCardViewModel = new BookCardViewModel
            {
                Authors = new MultiSelectList(allAuthors, "Id", "Name")
            };

            return View(bookCardViewModel);
        }

        [HttpPost]
        public ActionResult Create(BookCardViewModel bookCardViewModel, Guid[] Id)
        {
            try
            {
                if (string.IsNullOrEmpty(bookCardViewModel.Title))
                {
                    IEnumerable<Author> allAuthors = _librarian.GetAllAuthors();
                    BookCardViewModel bookViewModel = new BookCardViewModel
                    {
                        Authors = new MultiSelectList(allAuthors, "Id", "Name")
                    };

                    return View(bookViewModel);
                }

                if (Id == null)
                {
                    Id = new Guid[] { };
                }

                Author[] authors = Id.Select(a => new Author { Id = a }).ToArray();
                BookCard bookCard = new BookCard(bookCardViewModel.Title, authors);
                _librarian.AddBook(bookCard);
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
                //TODO: add logging of exception
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
                throw;
                //TODO: add logging of exception
            }
        }
        
        public ActionResult Delete(Guid id)
        {
            BookCard bookCard = _librarian.GetBookCardById(id);
            BookCardViewModel bookCardViewModel = new BookCardViewModel
            {
                Id = bookCard.Id,
                Title = bookCard.Title,
                BookAuthors = new SelectList(
                        _librarian.GetAuthorsByBookId(bookCard.Id).Select(a => a.Name).ToList())
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
                throw;
                //TODO: add logging of exception
            }
        }        

        public ActionResult ReturnBook(Guid id)
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
        public ActionResult ReturnBook(BookCardViewModel bookCardViewModel)
        {
            try
            {
                bookCardViewModel.registerResult = _librarian.ReturnBook(bookCardViewModel.Id);
                if (!(bool)bookCardViewModel.registerResult)
                {
                    ViewBag.RecordResult =
                        "This can't be executed. The book has been returned already.";
                    // TODO: js make button unable if book is able
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
                //TODO: add logging of exception
            }
        }
    }
}
