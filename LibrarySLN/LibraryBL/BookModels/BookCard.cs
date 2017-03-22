using System;
using System.Collections.Generic;

namespace LibraryBL.BookModels
{
    public class BookCard
    {
        List<Author> authors = new List<Author>();

        public BookCard()
        {
            this.Id = Guid.NewGuid();
            Records = new List<Record>();
        }

        public BookCard(string title, params Author[] author ): this()
        {
            if(author != null)
            {
                authors.AddRange(author);
            }

            this.Title = title;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public IList<Author> Authors { get { return authors; } }

        public IList<Record> Records { get; set; }
    }
}
