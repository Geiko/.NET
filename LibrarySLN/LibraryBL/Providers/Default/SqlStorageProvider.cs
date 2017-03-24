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
                    throw;
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
                    throw;
                }
            }
        }


        public bool AddAuthorToBook(Guid bookId, Guid authorId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from BookAuthor", connection);
                    DataSet ds = new DataSet("BookAuthor");
                    adapter.Fill(ds, "BookAuthor");

                    DataRow newCustomersRow = ds.Tables["BookAuthor"].NewRow();
                    newCustomersRow["BookCardId"] = bookId;
                    newCustomersRow["AuthorId"] = authorId;

                    ds.Tables["BookAuthor"].Rows.Add(newCustomersRow);
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "BookAuthor");
                    ds.Clear();
                    return true;
                }
                catch (Exception)
                {
                    throw;
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
                            }).OrderBy(b => b.Title);

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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Records", connection);
                    DataSet dsRecords = new DataSet("Records");
                    adapter.Fill(dsRecords, "Records");

                    SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from BookCards", connection);
                    DataSet dsBooks = new DataSet("BookCards");
                    adapter2.Fill(dsBooks, "BookCards");

                    var takenBookId = dsRecords.Tables["Records"].AsEnumerable()
                                        .Where(r => r.Field<DateTime?>("ReturnTime") == null)
                                        .Select(r => r.Field<Guid>("BookCardId"));

                    var allBookId = dsBooks.Tables["BookCards"].AsEnumerable()
                                        .Select(b => b.Field<Guid>("Id"));
                    var availableBookId = allBookId.Except(takenBookId);

                    var bookCards = dsBooks.Tables["BookCards"].AsEnumerable()
                            .Where(b => availableBookId.Contains(b.Field<Guid>("Id")))
                            .Select(
                            dataRow => new BookCard
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Title = dataRow.Field<string>("Title")
                            }).OrderBy(b => b.Title);

                    return bookCards;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<BookCard> GetBookCards(string title, Author[] author)
        {
            throw new NotImplementedException();
        }

        public bool GetoutBook(Record record)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Records", connection);
                    DataSet ds = new DataSet("Records");
                    adapter.Fill(ds, "Records");

                    DataRow newCustomersRow = ds.Tables["Records"].NewRow();

                    newCustomersRow["Id"] = record.Id;
                    newCustomersRow["BookCardId"] = record.BookCardId;
                    newCustomersRow["UserEmail"] = record.UserEmail;
                    newCustomersRow["GetoutTime"] = record.GetoutTime;

                    ds.Tables["Records"].Rows.Add(newCustomersRow);

                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Records");
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }



        public bool ReturnBook(Guid bookId, DateTime returnTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Records", connection);
                    DataSet ds = new DataSet("Records");
                    adapter.Fill(ds, "Records");

                    var recordToEdit = ds.Tables["Records"].AsEnumerable()
                                            .Where(r =>
                                                        r.Field<Guid>("BookCardId") == bookId &&
                                                        r.Field<DateTime?>("ReturnTime") == null)
                                            .Single();
                    recordToEdit["ReturnTime"] = returnTime;

                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Records");
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Record> GetRecords(Guid bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Records", connection);
                    DataSet ds = new DataSet("Records");
                    adapter.Fill(ds, "Records");

                    var records = ds.Tables["Records"].AsEnumerable()
                                        .Where(r => r.Field<Guid>("BookCardId") == bookId)
                                        .Select(dataRow => new Record
                                        {
                                            UserEmail = dataRow.Field<string>("UserEmail").Trim(),
                                            GetoutTime = dataRow.Field<DateTime>("GetoutTime"),
                                            ReturnTime = dataRow.Field<DateTime?>("ReturnTime"),
                                        }).OrderBy(r => r.GetoutTime);
                    return records;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Record> GetRecords(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Records", connection);
                    DataSet ds = new DataSet("Records");
                    adapter.Fill(ds, "Records");

                    var records = ds.Tables["Records"].AsEnumerable()
                                        .Where(r => r.Field<string>("UserEmail").Trim() == email)
                                        .Select(dataRow => new Record
                                        {
                                            BookCardId = dataRow.Field<Guid>("BookCardId"),
                                            GetoutTime = dataRow.Field<DateTime>("GetoutTime"),
                                            ReturnTime = dataRow.Field<DateTime?>("ReturnTime"),
                                        }).OrderBy(r => r.GetoutTime);
                    return records;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<BookCard> GetTakenBookCards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Records", connection);
                    DataSet dsRecords = new DataSet("Records");
                    adapter.Fill(dsRecords, "Records");

                    SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from BookCards", connection);
                    DataSet dsBooks = new DataSet("BookCards");
                    adapter2.Fill(dsBooks, "BookCards");

                    var takenBookId = dsRecords.Tables["Records"].AsEnumerable()
                                        .Where(r => r.Field<DateTime?>("ReturnTime") == null)
                                        .Select(r => r.Field<Guid>("BookCardId"));

                    var bookCards = dsBooks.Tables["BookCards"].AsEnumerable()
                            .Where(b => takenBookId.Contains(b.Field<Guid>("Id")))
                            .Select(
                            dataRow => new BookCard
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Title = dataRow.Field<string>("Title")
                            }).OrderBy(b => b.Title);

                    return bookCards;
                }
                catch (Exception)
                {
                    throw;
                }
            }
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


                    SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from Records", connection);
                    DataSet ds2 = new DataSet("Records");
                    adapter2.Fill(ds2, "Records");

                    ds2.Tables["Records"].AsEnumerable()
                                        .Where(r => r.Field<Guid>("BookCardId") == id)
                                        .ToList().ForEach(row => row.Delete());

                    SqlCommandBuilder objCommandBuilder2 = new SqlCommandBuilder(adapter2);
                    adapter2.Update(ds2, "Records");
                    return true;
                }
                catch (Exception)
                {
                    throw;
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
                    throw;
                }
            }
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
                    throw;
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
                    throw;
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

        public bool isBookAvailable(Guid bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Records", connection);
                    DataSet ds = new DataSet("Records");
                    adapter.Fill(ds, "Records");

                    var isBookAvailable = ds.Tables["Records"].AsEnumerable()
                                        .Where(r => r.Field<Guid>("BookCardId") == bookId)
                                        .All(r => r.Field<DateTime?>("ReturnTime") != null);

                    //SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(adapter);
                    //adapter.Update(ds, "Records");
                    return isBookAvailable;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}