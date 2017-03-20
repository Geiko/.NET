using System;

namespace LibraryBL.BookModels
{
    public class Record
    {
        public int Id { get; set; }

        public Guid BookCardId { get; set; }
        public int UserId { get; set; }

        public DateTime GetoutTime { get; set; }
        public DateTime? ReturnTime { get; set; }        
    }
}
