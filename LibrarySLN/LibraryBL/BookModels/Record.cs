using System;

namespace LibraryBL.BookModels
{
    public class Record
    {
        public Record()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid BookCardId { get; set; }
        public string UserEmail { get; set; }
        public DateTime GetoutTime { get; set; }
        public DateTime? ReturnTime { get; set; }        
    }
}
