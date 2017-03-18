using LibraryBL.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.UserModels
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        //public ICollection<Card> BookCards { get; set; }
    }
}
