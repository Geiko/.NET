using LibraryBL.BookModels;
using System.Collections.Generic;
using System;
using LibraryBL.UserModels;

namespace LibraryBL.ManagerModels
{
    public interface IStorageProvider
    {
        bool AddBookCard(BookCard bookCard);
        IEnumerable<BookCard> GetBookCards(string title, Author[] author);
        bool AddBookCards(int increment, string title, params Author[] authors);
        bool RemoveBookCard(Guid id);
        IEnumerable<BookCard> GetAllBookCards();
        bool AddUser(string email);
        IEnumerable<User> GetAllUsers();
        bool RemoveUser(string email);
        bool UpdateUser(string email, object newEmail);
        bool GetoutBook(Guid bookId, int userId);
        IEnumerable<Record> GetRecords(Guid bookId);
        bool ReturnBook(Guid bookId);
        IEnumerable<BookCard> GetAvailableBookCards();
        IEnumerable<BookCard> GetTakenBookCards();
    }
}