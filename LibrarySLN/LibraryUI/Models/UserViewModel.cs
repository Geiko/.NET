using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibraryUI.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "User Email")]
        [EmailAddress( ErrorMessage = "Invalid Email")]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User OldEmail")]
        [EmailAddress(ErrorMessage = "Invalid OldEmail")]
        [StringLength(80)]
        public string OldEmail { get; set; }

        public bool? registerResult { get; set; }

        public SelectList Records { get; set; }
    }    
}