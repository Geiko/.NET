using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string OldEmail { get; set; }
        public bool? registerResult { get; set; }
    }
}