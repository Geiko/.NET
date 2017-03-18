using LibraryBL.BookModels;
using LibraryBL.ManagerModels;
using LibraryBL.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.LibraryModels
{
    public class MyLibrary
    {
        public ICollection<BookCard> BookCards { get; set; }

        public ICollection<User> Users { get; set; }

        public Librarian Librarian { get; set; }
    }
}
