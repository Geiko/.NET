using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibraryUI.Models
{
    public class BookCardViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        [StringLength(200, ErrorMessage = "Book Title must be less than 200 symbols")]
        public string Title { get; set; }       
         
        public bool isAvailable { get; set; }

        public bool? registerResult { get; set; }

        public SelectList Records { get; set; }

        public MultiSelectList Authors { get; set; }

        public SelectList BookAuthors { get; set; }

        public PagedList.IPagedList<BookCardViewModel> BookCards { get; set; }
    }
}