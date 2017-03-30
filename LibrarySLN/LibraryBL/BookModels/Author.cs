using System;
using System.Security.Cryptography;

namespace LibraryBL.BookModels
{
    public class Author
    {
        public Author()
        {

        }

        public Author(string name)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(name);
            byte[] hash = md5.ComputeHash(inputBytes);
            Guid hashGuid = new Guid(hash);
            this.Id = hashGuid;
            this.Name = name;
        }
        
        public Guid Id { get; set; } 
        public string Name { get; set; }
    }
}