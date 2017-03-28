using System;

namespace LibraryUI.Models
{
    public class UserRecordsViewModel
    {
        public string BookTitle { get; set; }
        public string FirstAuthor { get; set; }
        public Guid BookId { get; set; }
        public DateTime GetoutTime { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}