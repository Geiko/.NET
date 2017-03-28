using System;
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
        public SelectList BookAuthors { get; set; }
        public PagedList.IPagedList<BookCardViewModel> BookCards { get; set; }
        public string AutorsStr { get; set; }
    }
}