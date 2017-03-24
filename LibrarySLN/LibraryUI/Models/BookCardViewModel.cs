using LibraryBL.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryUI.Models
{
    public class BookCardViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public bool isAvailable { get; set; }

        public bool? registerResult { get; set; }

        public SelectList Records { get; set; }

        public MultiSelectList Authors { get; set; }

        public PagedList.IPagedList<BookCardViewModel> BookCards { get; set; }
    }
}