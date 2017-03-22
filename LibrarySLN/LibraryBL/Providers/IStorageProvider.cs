using LibraryBL.BookModels;
using System.Collections.Generic;
using System;
using LibraryBL.UserModels;

namespace LibraryBL.Providers
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
        bool GetoutBook(Guid bookId, string userId);
        IEnumerable<Record> GetRecords(Guid bookId);
        bool ReturnBook(Guid bookId);
        IEnumerable<BookCard> GetAvailableBookCards();
        IEnumerable<BookCard> GetTakenBookCards();
        IEnumerable<Record> GetUserRecords(string userEmail);
        IEnumerable<Author> GetAllAuthors();
        bool AddAuthor(string name, Guid id);
        Author GetAuthorById(Guid id);
        bool RemoveAuthor(Guid id);
        bool UpdateAuthor(Guid idToEdit, Author author);
        BookCard GetBookCardById(Guid id);
        bool UpdateBookCard(Guid idToEdit, BookCard bookCard);
    }
}