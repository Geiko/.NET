using System;
using System.Collections.Generic;
using LibraryBL.BookModels;
using LibraryBL.UserModels;

namespace LibraryBL.ManagerModels
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
        

        public bool AddBooks(int increment, string title, params Author[] authors)
        {
            return this.provider.AddBookCards(increment, title, authors);
        }


        public bool RemoveBookCard(Guid id)
        {
            return this.provider.RemoveBookCard(id);
        }
        

        public IEnumerable<BookCard> GetAllBookCards()
        {
            return this.provider.GetAllBookCards();
        }

        public bool AddUser(string email)
        {
            return this.provider.AddUser(email);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.provider.GetAllUsers();
        }

        public bool RemoveUser(string email)
        {
            return this.provider.RemoveUser(email);
        }

        public bool UpdateUser(string email, object newEmail)
        {
            return this.provider.UpdateUser(email, newEmail);
        }

        public bool GetoutBook(Guid bookId, int userId)
        {
            return this.provider.GetoutBook(bookId, userId);
        }

        public IEnumerable<Record> GetBookRecords(Guid bookId)
        {
            return this.provider.GetRecords(bookId);
        }

        public bool ReturnBook(Guid bookId)
        {
            return this.provider.ReturnBook(bookId);
        }

        public IEnumerable<BookCard> GetAvailableBookCards()
        {
            return this.provider.GetAvailableBookCards();
        }

        public IEnumerable<BookCard> GetTakenBookCards()
        {
            return this.provider.GetTakenBookCards();
        }

        public IEnumerable<Record> GetUserRecords(int userId)
        {
            return this.provider.GetUserRecords(userId);
        }
    }
}