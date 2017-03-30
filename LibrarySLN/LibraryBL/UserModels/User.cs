namespace LibraryBL.UserModels
{
    public class User
    {
        public User()
        {

        }

        public User(string email)
        {
            this.Email = email;
        }
        
        public string Email { get; set; }
    }
}
