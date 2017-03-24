using LibraryBL.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryUI.Areas.Admin.Models
{
    public class RecordViewModel
    {
        public BookCard BookCard { get; set; }
        public SelectList AllUsers { get; set; }
        public bool isBookAvailable { get; set; }
    }
}