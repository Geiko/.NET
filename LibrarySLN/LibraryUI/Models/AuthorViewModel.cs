using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI.Models
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool? registerResult { get; set; }
    }
}