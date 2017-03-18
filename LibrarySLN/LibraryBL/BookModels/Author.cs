using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.BookModels
{
    public class Author
    {
        public Author(string authorName)
        {
            this.Name = authorName;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
