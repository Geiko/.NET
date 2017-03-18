using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.BookModels
{
    public class BookCard
    {
        List<Author> authors = new List<Author>();

        public BookCard()
        {
            this.Id = Guid.NewGuid();
        }

        public BookCard(string title, params Author[] author ): this()
        {
            authors.AddRange(author);
            this.Title = title;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public IList<Author> Authors { get { return authors; } }

        public IList<Record> Records { get;}
    }
}
