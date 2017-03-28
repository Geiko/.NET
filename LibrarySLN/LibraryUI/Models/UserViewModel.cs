using System.Web.Mvc;

namespace LibraryUI.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string OldEmail { get; set; }
        public bool? registerResult { get; set; }
        public SelectList Records { get; set; }
        public string creatingUserMessage { get; set; }
    }    
}