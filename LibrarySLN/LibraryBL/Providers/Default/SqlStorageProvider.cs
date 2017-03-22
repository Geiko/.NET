using System;
using System.Collections.Generic;
using LibraryBL.BookModels;
using LibraryBL.UserModels;
using System.Data.SqlClient;
using System.Data;
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

                    var bookCards = ds.Tables["BookCards"].AsEnumerable().Select(
                            dataRow => new BookCard
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Title = dataRow.Field<string>("Title")
                            });

                    return bookCards;
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

                    var users =
                        ds.Tables["Users"].AsEnumerable().Select(
                            dataRow => new User { Email = dataRow.Field<string>("Email").Trim() });

                    return users;
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

        public bool GetoutBook(Guid bookId, string userEmail)
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

        public IEnumerable<Record> GetUserRecords(string userEmail)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBookCard(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from BookCards", connection);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");

                    ds.Tables["BookCards"].AsEnumerable()
                                        .Where(r => r.Field<Guid>("Id") == id)
                                        .ToList().ForEach(row => row.Delete());

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
        
        public bool RemoveUser(string emailToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users", connection);
                    DataSet ds = new DataSet("Users");
                    adapter.Fill(ds, "Users");

                    ds.Tables["Users"].AsEnumerable()
                                        .Where(r => r.Field<string>("Email").Trim() == emailToDelete)
                                        .ToList().ForEach(row => row.Delete());

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
        
        public bool ReturnBook(Guid bookId)
        {
            throw new NotImplementedException();
        }
        
        public bool UpdateUser(string oldEmail, object newEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users", connection);
                    DataSet ds = new DataSet("Users");
                    adapter.Fill(ds, "Users");

                    DataRow dr = ds.Tables["Users"].AsEnumerable()
                                        .Where(r => r.Field<string>("Email").Trim() == oldEmail).Single();
                    dr["Email"] = newEmail;

                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Users");
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        public IEnumerable<Author> GetAllAuthors()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Authors", connection);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");

                    var authors = ds.Tables["Authors"].AsEnumerable().Select(
                                            dataRow => new Author
                                            {
                                                Id = dataRow.Field<Guid>("Id"),
                                                Name = dataRow.Field<string>("Name").Trim()
                                            });
                    return authors;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        public bool AddAuthor(string name, Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Authors", connection);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");
                    DataRow newCustomersRow = ds.Tables["Authors"].NewRow();
                    newCustomersRow["Id"] = id;
                    newCustomersRow["Name"] = name;
                    ds.Tables["Authors"].Rows.Add(newCustomersRow);
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Authors");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public Author GetAuthorById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Authors", connection);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");

                    var authorRow = ds.Tables["Authors"].AsEnumerable()
                                                .Where(r => r.Field<Guid>("Id") == id)
                                                .Single();
                    var author = new Author
                    {
                        Id = (Guid)authorRow["Id"],
                        Name = authorRow["Name"].ToString().Trim()
                    };

                    return author;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        public bool RemoveAuthor(Guid idToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Authors", connection);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");

                    ds.Tables["Authors"].AsEnumerable()
                                        .Where(r => r.Field<Guid>("Id") == idToDelete)
                                        .ToList().ForEach(row => row.Delete());

                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Authors");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public bool UpdateAuthor(Guid idToEdit, Author author)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Authors", connection);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");

                    DataRow dr = ds.Tables["Authors"].AsEnumerable()
                                        .Where(r => r.Field<Guid>("Id") == idToEdit).Single();
                    dr["Name"] = author.Name;

                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Authors");
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        public BookCard GetBookCardById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from BookCards", connection);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");

                    var bookCardRow = ds.Tables["BookCards"].AsEnumerable()
                                                .Where(r => r.Field<Guid>("Id") == id)
                                                .Single();
                    var bookCard = new BookCard
                    {
                        Id = (Guid)bookCardRow["Id"],
                        Title = bookCardRow["Title"].ToString().Trim()
                    };

                    return bookCard;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        public bool UpdateBookCard(Guid idToEdit, BookCard bookCard)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from BookCards", connection);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");

                    DataRow dr = ds.Tables["BookCards"].AsEnumerable()
                                        .Where(r => r.Field<Guid>("Id") == idToEdit).Single();
                    dr["Title"] = bookCard.Title;

                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "BookCards");
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}