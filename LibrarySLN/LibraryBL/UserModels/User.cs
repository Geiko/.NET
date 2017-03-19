using System;

namespace LibraryBL.UserModels
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public User()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
