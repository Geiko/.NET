using LibraryBL.BookModels;
using LibraryBL.UserModels;
using System;
using System.Collections.Generic;

namespace LibraryBL.ManagerModels
{
    public interface ILibrarian
    {
        bool AddBook(BookCard bookCard);                                         
        bool AddBooks(int increment, string title, params Author[] authors);     
        bool RemoveBookCard(Guid id);                                               

        bool AddUser(string email);                                              
        bool UpdateUser(string email, object newEmail);                          
        bool RemoveUser(string email);                                           

        bool GetoutBook(Guid bookId, int userId);                              
        bool ReturnBook(Guid bookId);                   

        IEnumerable<BookCard> GetCards(string title, params Author[] author);     
        IEnumerable<BookCard> GetAllBookCards();                                     
        IEnumerable<BookCard> GetAvailableBookCards();                           
        IEnumerable<BookCard> GetTakenBookCards();                           

        IEnumerable<User> GetAllUsers();                                   
        
        IEnumerable<Record> GetBookRecords(Guid bookId);                      
        IEnumerable<Record> GetUserRecords(int userId);                          
    }
}
