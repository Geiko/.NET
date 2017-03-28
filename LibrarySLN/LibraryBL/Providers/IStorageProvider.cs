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
        IEnumerable<Record> GetRecords(Guid bookId);
        IEnumerable<BookCard> GetAvailableBookCards();
        IEnumerable<BookCard> GetTakenBookCards();
        IEnumerable<Record> GetUserRecords(string userEmail);
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(Guid id);
        bool RemoveAuthor(Guid id);
        bool UpdateAuthor(Guid idToEdit, Author author);
        BookCard GetBookCardById(Guid id);
        bool UpdateBookCard(Guid idToEdit, BookCard bookCard);
        bool GetoutBook(Record record);
        bool isBookAvailable(Guid id);
        bool ReturnBook(Guid bookId, DateTime returnTime);
        IEnumerable<Record> GetRecords(string email);
        IEnumerable<Author> GetAuthorsByBookId(Guid id);
        IEnumerable<BookCard> GetBookCardsByAuthorId(Guid authorId);
        bool AddAuthor(Author author);
    }
}