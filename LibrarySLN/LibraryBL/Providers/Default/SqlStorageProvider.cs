using System;
using System.Collections.Generic;
using LibraryBL.BookModels;
using LibraryBL.UserModels;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;

namespace LibraryBL.Providers.Default
{
    public class SqlStorageProvider : IStorageProvider
    {
        private string connectionString;



        public SqlStorageProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public bool AddUser(string newEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users", connection);
                    DataSet ds = new DataSet("Users");
                    adapter.Fill(ds, "Users");
                    DataRow newCustomersRow = ds.Tables["Users"].NewRow();
                    newCustomersRow["Email"] = newEmail;
                    ds.Tables["Users"].Rows.Add(newCustomersRow);
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Users");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public bool AddBookCard(BookCard bookCard)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from BookCards", connection);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");
                    DataRow newCustomersRow = ds.Tables["BookCards"].NewRow();
                    newCustomersRow["Id"] = bookCard.Id;
                    newCustomersRow["Title"] = bookCard.Title;
                    ds.Tables["BookCards"].Rows.Add(newCustomersRow);
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "BookCards");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public bool AddBookCards(int increment, string title, params Author[] authors)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<BookCard> GetAllBookCards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = 
                            new SqlDataAdapter("Select * from BookCards", connection);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");

                    var empList = ds.Tables["BookCards"].AsEnumerable().Select(
                            dataRow => new BookCard {
                                    Id = dataRow.Field<Guid>("Id"),
                                    Title = dataRow.Field<string>("Title") });

                    return empList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }





        public IEnumerable<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users", connection);
                    DataSet ds = new DataSet("Users");
                    adapter.Fill(ds, "Users");

                    var empList =
                        ds.Tables["Users"].AsEnumerable().Select(
                            dataRow => new User { Email = dataRow.Field<string>("Email") });

                    return empList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
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