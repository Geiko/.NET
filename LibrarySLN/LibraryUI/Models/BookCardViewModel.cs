using LibraryBL.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI.Models
{
    public class BookCardViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Author> Authors { get; set; }

        public bool isAvailable { get; set; }

        public bool? registerResult { get; set; }
    }
}