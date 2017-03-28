using System;
using System.Web.Mvc;

namespace LibraryUI.Models
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? registerResult { get; set; }
        public SelectList AuthorBooks { get; set; }
    }
}