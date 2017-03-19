using LibraryBL.BookModels;
using LibraryBL.UserModels;
using System;
using System.Collections.Generic;

namespace LibraryBL.ManagerModels
{
    interface ILibrarian
    {
        bool AddBook(BookCard bookCard);                                            // implemented tested
        bool AddBooks(int increment, string title, params Author[] authors);        // implemented tested
        bool RemoveBookCard(Guid id);                                               // implemented tested     

        bool AddUser(string email);                                                 // implemented tested
        bool UpdateUser(string email, object newEmail);                             // implemented tested
        bool RemoveUser(string email);                                              // implemented tested

        bool GetoutBook(Guid bookId, int userId);                                   // implemented tested
        bool ReturnBook(Guid bookId);                                               // implemented tested
        bool SendMessageToUser(List<BookCard> books);

        IEnumerable<BookCard> GetCard(string title, params Author[] author);        // implemented 
        IEnumerable<BookCard> GetAllBookCards();                                    // implemented         
        IEnumerable<BookCard> GetAvailableBookCards();                              // implemented tested
        IEnumerable<BookCard> GetTakenBookCards();                                  // implemented tested

        IEnumerable<User> GetAllUsers();                                            // implemented
        
        IEnumerable<Record> GetBookRecords(Guid bookId);                            // implemented
        IEnumerable<Record> GetUserRecords(User user);
    }
}
