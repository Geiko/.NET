namespace LibraryBL.BookModels
{
    public class Author
    {
        public Author(string authorName)
        {
            this.Name = authorName;
        }
        // TODO: fix id
        //public int Id { get; set; } 

        public string Name { get; set; }
    }
}
