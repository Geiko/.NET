using System;

namespace Library.Models
{
    public class BookRecord
    {
        public string Author { get; set; }
        public Guid Id { get { return Guid.Empty; }  }
        public string Title { get; set; }

    }
}