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

        //public int Id { get; set; }

        public string Email { get; set; }
        
        // TODO: Id - Email hashcode?
    }
}
