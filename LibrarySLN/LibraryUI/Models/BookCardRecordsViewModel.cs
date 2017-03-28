using System;

namespace LibraryUI.Models
{
    public class BookCardRecordsViewModel
    {
        public string UserEmail { get; set; }
        public DateTime GetoutTime { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}