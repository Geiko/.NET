using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibraryUI.Models
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Author Name")]
        [StringLength(200, ErrorMessage = "Author Name must be less than 200 symbols")]
        public string Name { get; set; }

        public bool? registerResult { get; set; }

        public SelectList AuthorBooks { get; set; }
    }
}