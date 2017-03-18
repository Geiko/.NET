using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBL.BookModels;
using LibraryBL.UserModels;

namespace LibraryBL.ManagerModels
{
    public class Librarian //: ILibrarian
    {

        public bool AddBook(BookCard book)
        {
            

            throw new NotImplementedException();
        }

        public ICollection<int> AddBooks(int increment, BookCard book)
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetCardbyTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetCardByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetCard(string title, params Author[] author)
        {
            throw new NotImplementedException();
        }

        public bool GetoutBook(BookCard book, User user)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBook(BookCard book)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool ReturnBook(BookCard book, User user)
        {
            throw new NotImplementedException();
        }

        public bool SendMessageToUser(List<BookCard> books)
        {
            throw new NotImplementedException();
        }

        public void ShowAllBooks()
        {
            throw new NotImplementedException();
        }

        public void ShowAvailableBooks()
        {
            throw new NotImplementedException();
        }

        public void ShowBookHistory(BookCard book)
        {
            throw new NotImplementedException();
        }

        public void ShowTakenBooks()
        {
            throw new NotImplementedException();
        }

        public void ShowUserHistory(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
