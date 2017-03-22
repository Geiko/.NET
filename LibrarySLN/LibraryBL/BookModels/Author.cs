using System;

namespace LibraryBL.BookModels
{
    public class Author
    {
        public Author()
        {
            this.Id = Guid.NewGuid();
        }

        public Author(string authorName) : this()
        {
            this.Name = authorName;
        }

        // TODO: fix id
        public Guid Id { get; set; } 

        public string Name { get; set; }
    }
}