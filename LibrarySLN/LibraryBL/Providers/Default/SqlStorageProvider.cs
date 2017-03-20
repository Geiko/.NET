using System;
using System.Collections.Generic;
using LibraryBL.BookModels;
using LibraryBL.UserModels;
using System.Data.SqlClient;
using System.Data;

namespace LibraryBL.Providers.Default
{
    public class SqlStorageProvider : IStorageProvider
    {
        private string connectionString;

        public SqlStorageProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        SqlConnection connection = new SqlConnection();//???????


        public bool AddBookCard(BookCard bookCard)
        {
            string query = "Select * from BookCard";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            return true;
        }

        public bool AddBookCards(int increment, string title, params Author[] authors)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetAllBookCards()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetAvailableBookCards()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetBookCards(string title, Author[] author)
        {
            throw new NotImplementedException();
        }

        public bool GetoutBook(Guid bookId, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetRecords(Guid bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetTakenBookCards()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetUserRecords(int userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBookCard(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(string email)
        {
            throw new NotImplementedException();
        }

        public bool ReturnBook(Guid bookId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(string email, object newEmail)
        {
            throw new NotImplementedException();
        }
    }
}