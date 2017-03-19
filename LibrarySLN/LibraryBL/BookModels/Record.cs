using System;

namespace LibraryBL.BookModels
{
    public class Record
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime GetoutTime { get; set; }
        public DateTime? ReturnTime { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Record r = (Record)obj;
            return  (
                        UserId == r.UserId) && 
                        (DateTime.Compare(GetoutTime, r.GetoutTime) == 0
                    );
        }

        public override int GetHashCode()
        {
            return UserId ^ GetoutTime.GetHashCode();
        }
    }
}
