using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.UserModels;
using System.Collections.Generic;

namespace LibraryBL.LibraryModels
{
    public class MyLibrary
    {
        public ICollection<BookCard> BookCards { get; set; }

        public ICollection<User> Users { get; set; }

        public Librarian Librarian { get; set; }
    }
}
