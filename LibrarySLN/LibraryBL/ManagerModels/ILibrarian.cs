using LibraryBL.BookModels;
using LibraryBL.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.ManagerModels
{
    interface ILibrarian
    {
        bool AddBook(BookCard book);
        ICollection<int> AddBooks(int increment, BookCard book);
        bool RemoveBook(BookCard book);

        IEnumerable<BookCard> GetCards(BookCard book);


        int AddUser(User user);
        bool UpdateUser(User user);
        bool RemoveUser(User user);

        bool GetoutBook(BookCard book, User user);
        bool ReturnBook(BookCard book, User user);
        bool SendMessageToUser(List<BookCard> books);

        void ShowAllBooks();
        void ShowAvailableBooks();
        void ShowTakenBooks();

        void ShowBookHistory(BookCard book);
        void ShowUserHistory(User user);
    }
}
