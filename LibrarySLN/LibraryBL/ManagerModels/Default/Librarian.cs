using System;
using System.Collections.Generic;
using LibraryBL.BookModels;
using LibraryBL.UserModels;
using LibraryBL.Providers;
using System.Linq;

namespace LibraryBL.ManagerModels.Default
{
    public class Librarian //: ILibrarian
    {
        IStorageProvider provider;

        private Librarian()
        {

        }

        public Librarian(IStorageProvider provider)
        {
            if (provider == null)
            {
                throw new Exception("Cannot create Librarian with null provider");
            }

            this.provider = provider;
        }

        public bool AddBook(BookCard bookCard)
        {
            return provider.AddBookCard(bookCard);
        }

        public IEnumerable<BookCard> GetCards(string title, params Author[] authors)
        {
            return this.provider.GetBookCards(title, authors);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return this.provider.GetAllAuthors().OrderBy(a => a.Name);
        }

        public bool AddBooks(int increment, string title, params Author[] authors)
        {
            return this.provider.AddBookCards(increment, title, authors);
        }

        public IEnumerable<BookCard> GetBookCardsByAuthorId(Guid authorId)
        {
            return this.provider.GetBookCardsByAuthorId(authorId);
        }

        public IEnumerable<Author> GetAuthorsByBookId(Guid id)
        {
            return this.provider.GetAuthorsByBookId(id);
        }

        public IEnumerable<string> GetAuthorNamesByBookId(Guid id)
        {
            return this.provider.GetAuthorsByBookId(id).Select(a => a.Name);
        }

        public IEnumerable<Record> GetBookRecords(string email)
        {
            return this.provider.GetRecords(email);
        }

        public bool isBookAvailable(Guid id)
        {
            return this.provider.isBookAvailable(id);
        }

        public bool RemoveBookCard(Guid id)
        {         
            return this.provider.RemoveBookCard(id);
        }

        public BookCard GetBookCardById(Guid id)
        {
            return this.provider.GetBookCardById(id);
        }

        public Author GetAuthorById(Guid id)
        {
            return this.provider.GetAuthorById(id);
        }

        public IEnumerable<BookCard> GetAllBookCards()
        {
            return this.provider.GetAllBookCards();
        }

        public bool AddUser(string email)
        {
            return this.provider.AddUser(email);
        }

        public bool AddAuthor(Author author)
        {
            return this.provider.AddAuthor(author);
        }
        
        public IEnumerable<User> GetAllUsers()
        {
            return this.provider.GetAllUsers();
        }

        public bool RemoveUser(string email)
        {
            return this.provider.RemoveUser(email);
        }

        public bool UpdateUser(string oldEmail, object newEmail)
        {
            var users = this.provider.GetAllUsers();
            if (users.Any(u => u.Email.Equals(newEmail)))
            {
                return false;
            }

            return this.provider.UpdateUser(oldEmail, newEmail);
        }
        
        public bool GetoutBook(Guid bookId, string tookBookUserEmail)
        {
            if (this.provider.isBookAvailable(bookId) == false)
            {
                return false;
            }

            Record record = new Record
            {
                Id = Guid.NewGuid(),
                BookCardId = bookId,
                UserEmail = tookBookUserEmail,
                GetoutTime = DateTime.Now,
                ReturnTime = null
            };

            return this.provider.GetoutBook(record);
        }

        public IEnumerable<Record> GetBookRecords(Guid bookId)
        {
            return this.provider.GetRecords(bookId);
        }

        public bool ReturnBook(Guid bookId)
        {
            if(this.provider.isBookAvailable(bookId) == true)
            {
                return false;
            }

            DateTime returnTime = DateTime.Now;

            return this.provider.ReturnBook(bookId, returnTime);
        }

        public bool UpdateBookCard(Guid idToEdit, BookCard bookCard)
        {
            return this.provider.UpdateBookCard(idToEdit, bookCard);
        }

        public bool UpdateAuthor(Guid idToEdit, Author author)
        {
            return this.provider.UpdateAuthor(idToEdit, author);
        }

        public IEnumerable<BookCard> GetAvailableBookCards()
        {
            return this.provider.GetAvailableBookCards();
        }

        public IEnumerable<BookCard> GetTakenBookCards()
        {
            return this.provider.GetTakenBookCards();
        }

        public IEnumerable<Record> GetUserRecords(string userEmail)
        {
            return this.provider.GetUserRecords(userEmail);
        }

        public bool RemoveAuthor(Guid id)
        {
            return this.provider.RemoveAuthor(id);
        }
        
    }
}