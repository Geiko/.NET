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
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO Users VALUES (@newEmail)";
                    command.Parameters.AddWithValue("@newEmail", newEmail);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
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
                    SqlCommand command = new SqlCommand();
                    command.CommandText = 
                            "INSERT INTO BookCards VALUES (@bookCardId, @bookCardTitle)";
                    command.Parameters.AddWithValue("@bookCardId", bookCard.Id);
                    command.Parameters.AddWithValue("@bookCardTitle", bookCard.Title);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    foreach (Author author in bookCard.Authors)
                    {
                        LinkingAuthorsToBook(bookCard.Id, author.Id, connection);
                    }
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        private bool LinkingAuthorsToBook(
                Guid bookId, Guid authorId, SqlConnection connection)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = 
                        "INSERT INTO BookAuthor VALUES (@BookCardId, @authorId)";
                command.Parameters.AddWithValue("@bookCardId", bookId);
                command.Parameters.AddWithValue("@authorId", authorId);
                command.Connection = connection;
                int number = command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool AddBookCards(
                int increment, string title, params Author[] authors)
        {
            throw new NotImplementedException();
        }

        public bool AddAuthor(Author author)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = 
                            "INSERT INTO Authors VALUES (@authorId, @authorName)";
                    command.Parameters.AddWithValue("@authorId", author.Id);
                    command.Parameters.AddWithValue("@authorName", author.Name);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public bool GetoutBook(Record record)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText =
                            @"INSERT INTO Records (Id, BookCardId, UserEmail, GetoutTime)
                            VALUES (@recordrId, @BookCardId, @UserEmail, @GetoutTime)";
                    command.Parameters.AddWithValue("@recordrId", record.Id);
                    command.Parameters.AddWithValue("@BookCardId", record.BookCardId);
                    command.Parameters.AddWithValue("@UserEmail", record.UserEmail);
                    command.Parameters.AddWithValue("@GetoutTime", record.GetoutTime);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
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
                    SqlCommand command = new SqlCommand();
                    command.CommandText =
                            @"UPDATE Records
                            SET ReturnTime = @returnTime
                            WHERE BookCardId = @bookId AND ReturnTime IS NULL";
                    command.Parameters.AddWithValue("@bookId", bookId);
                    command.Parameters.AddWithValue("@returnTime", returnTime);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<BookCard> GetAllBookCards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from BookCards", connection);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");
                    return ds.Tables["BookCards"].AsEnumerable().Select(
                            dataRow => new BookCard
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Title = dataRow.Field<string>("Title")
                            }).OrderBy(b => b.Title);
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from Users", connection);
                    DataSet ds = new DataSet("Users");
                    adapter.Fill(ds, "Users");
                    return ds.Tables["Users"].AsEnumerable()
                            .Select(dataRow => new User
                            {
                                Email = dataRow.Field<string>("Email").Trim()
                            });
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<BookCard> GetBookCards(string title, Author[] author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetRecords(Guid bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from Records Where BookCardId = @bookId",
                            connection);
                    adapter.SelectCommand.Parameters.AddWithValue("bookId", bookId);
                    DataSet ds = new DataSet("Records");
                    adapter.Fill(ds, "Records");
                    return ds.Tables["Records"].AsEnumerable()
                            .Select(dataRow => new Record
                            {
                                UserEmail = dataRow.Field<string>("UserEmail").Trim(),
                                GetoutTime = dataRow.Field<DateTime>("GetoutTime"),
                                ReturnTime = dataRow.Field<DateTime?>("ReturnTime"),
                            }).OrderBy(r => r.GetoutTime);
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<Record> GetRecords(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from Records Where RTRIM(UserEmail) = @email",
                            connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@email", email);
                    DataSet ds = new DataSet("Records");
                    adapter.Fill(ds, "Records");
                    return ds.Tables["Records"].AsEnumerable()
                            .Select(dataRow => new Record
                            {
                                BookCardId = dataRow.Field<Guid>("BookCardId"),
                                GetoutTime = dataRow.Field<DateTime>("GetoutTime"),
                                ReturnTime = dataRow.Field<DateTime?>("ReturnTime"),
                            }).OrderBy(r => r.GetoutTime);
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from Authors", connection);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");
                    return ds.Tables["Authors"].AsEnumerable().Select(
                            dataRow => new Author
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Name = dataRow.Field<string>("Name").Trim()
                            });
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public bool RemoveBookCard(Guid bookIdToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    RemoveRecordsByBookCardId(bookIdToDelete);
                    RemoveBookToAuthorByBookCardId(bookIdToDelete);
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = 
                            "Delete from BookCards Where Id = @bookIdToDelete";
                    command.Parameters.AddWithValue(
                            "@bookIdToDelete", bookIdToDelete);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }
        public bool RemoveRecordsByBookCardId(Guid bookIdToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = 
                            "Delete from Records Where BookCardId = @bookIdToDelete";
                    command.Parameters.AddWithValue(
                            "@bookIdToDelete", bookIdToDelete);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public bool RemoveBookToAuthorByBookCardId(Guid bookIdToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText =
                            "Delete from BookAuthor Where BookCardId = @bookIdToDelete";
                    command.Parameters.AddWithValue("@bookIdToDelete", bookIdToDelete);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public bool RemoveUser(string emailToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //Remove User Records
                    connection.Open();
                    SqlCommand recordCommand = new SqlCommand();
                    recordCommand.CommandText = 
                            "Delete from Records Where UserEmail = @emailToDelete";
                    recordCommand.Parameters.AddWithValue(
                            "@emailToDelete", emailToDelete);
                    recordCommand.Connection = connection;
                    int number1 = recordCommand.ExecuteNonQuery();
                    //Remove User
                    SqlCommand userCommand = new SqlCommand();
                    userCommand.CommandText = 
                            "Delete from Users Where Email = @emailToDelete";
                    userCommand.Parameters.AddWithValue(
                            "@emailToDelete", emailToDelete);
                    userCommand.Connection = connection;
                    int number2 = userCommand.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
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
                    SqlCommand command = new SqlCommand();
                    command.CommandText =
                            @"UPDATE Users
                            SET Email = @newEmail
                            WHERE Email = @oldEmail";
                    command.Parameters.AddWithValue("@oldEmail", oldEmail);
                    command.Parameters.AddWithValue("@newEmail", newEmail);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public Author GetAuthorById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from Authors where Id = @id", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");
                    var authorRow = ds.Tables["Authors"].Rows[0];
                    return new Author
                    {
                        Id = (Guid)authorRow["Id"],
                        Name = authorRow["Name"].ToString().Trim()
                    };
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public bool RemoveAuthor(Guid authorIdToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //Remove Rows from table BookAuthor
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = 
                            "Delete from BookAuthor Where AuthorId = @authorIdToDelete";
                    command.Parameters.AddWithValue(
                            "@authorIdToDelete", authorIdToDelete);
                    command.Connection = connection;
                    int number = command.ExecuteNonQuery();
                    //Remove Author
                    SqlCommand authorCommand = new SqlCommand();
                    authorCommand.CommandText = 
                            "Delete from Authors Where Id = @authorIdToDelete";
                    authorCommand.Parameters.AddWithValue(
                            "@authorIdToDelete", authorIdToDelete);
                    authorCommand.Connection = connection;
                    int number2 = authorCommand.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public bool UpdateAuthor(Guid idToEdit, Author author)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from Authors where Id = @idToEdit",
                            connection);
                    adapter.SelectCommand.Parameters.AddWithValue(
                            "@idToEdit", idToEdit);
                    DataSet ds = new DataSet("Authors");
                    adapter.Fill(ds, "Authors");
                    ds.Tables["Authors"].Rows[0]["Name"] = author.Name;
                    SqlCommandBuilder objCommandBuilder =
                            new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "Authors");
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public BookCard GetBookCardById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from BookCards where Id = @id", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");
                    var bookCardRow = ds.Tables["BookCards"].Rows[0];
                    return new BookCard
                    {
                        Id = (Guid)bookCardRow["Id"],
                        Title = bookCardRow["Title"].ToString().Trim()
                    };
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public bool UpdateBookCard(Guid idToEdit, BookCard bookCard)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            "Select * from BookCards where Id = @idToEdit",
                            connection);
                    adapter.SelectCommand.Parameters.AddWithValue(
                            "@idToEdit", idToEdit);
                    DataSet ds = new DataSet("BookCards");
                    adapter.Fill(ds, "BookCards");
                    ds.Tables["BookCards"].Rows[0]["Title"] = bookCard.Title;
                    SqlCommandBuilder objCommandBuilder =
                            new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "BookCards");
                    return true;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
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
                    SqlCommand command = new SqlCommand();
                    command.CommandText =
                            @"Select Count(BookCardId) from Records
                            where BookCardId = @bookId and ReturnTime is null";
                    command.Parameters.AddWithValue("@bookId", bookId);
                    command.Connection = connection;
                    return (int)command.ExecuteScalar() <= 0;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<Record> GetUserRecords(string userEmail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCard> GetBookCardsByAuthorId(Guid authorId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter1 = new SqlDataAdapter(
                            @"Select * from BookCards
                            inner join BookAuthor
                            on BookCards.Id = BookAuthor.BookCardId
                            inner join Authors
                            on Authors.Id = BookAuthor.AuthorId
                            where Authors.Id = @authorId",
                            connection);
                    adapter1.SelectCommand.Parameters.AddWithValue(
                            "@authorId", authorId);
                    DataSet ds1 = new DataSet("Books");
                    adapter1.Fill(ds1, "Books");
                    return ds1.Tables["Books"].AsEnumerable()
                            .Select(dataRow => new BookCard
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Title = dataRow.Field<string>("Title")
                            }).OrderBy(a => a.Title);
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<Author> GetAuthorsByBookId(Guid bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter1 = new SqlDataAdapter(
                            @"Select * from Authors 
                            inner join BookAuthor
                            on Authors.Id = BookAuthor.AuthorId
                            inner join BookCards
                            on BookCards.Id = BookAuthor.BookCardId
                            where BookCards.Id = @bookId",
                            connection);
                    adapter1.SelectCommand.Parameters.AddWithValue(
                            "@bookId", bookId);
                    DataSet ds1 = new DataSet("Authors");
                    adapter1.Fill(ds1, "Authors");
                    var authors = ds1.Tables["Authors"].AsEnumerable()
                            .Select(dataRow => new Author
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Name = dataRow.Field<string>("Name")
                            }).OrderBy(a => a.Name);
                    return authors;
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<BookCard> GetTakenBookCards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            @"Select * from BookCards 
                            inner join Records
                            on BookCards.Id = Records.BookCardId
                            where Records.ReturnTime IS NULL",
                            connection);
                    DataSet ds = new DataSet("TakenBookCards");
                    adapter.Fill(ds, "TakenBookCards");
                    return ds.Tables["TakenBookCards"].AsEnumerable().Select(
                            dataRow => new BookCard
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Title = dataRow.Field<string>("Title")
                            }).OrderBy(b => b.Title);
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }

        public IEnumerable<BookCard> GetAvailableBookCards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                            @"Select * from BookCards 
                            EXCEPT
                            Select BookCards.Id, BookCards.Title from BookCards
                            inner join Records
                            on BookCards.Id = Records.BookCardId
                            where Records.ReturnTime IS NULL",
                            connection);
                    DataSet ds = new DataSet("AvailableBooks");
                    adapter.Fill(ds, "AvailableBooks");
                    return ds.Tables["AvailableBooks"].AsEnumerable().Select(
                            dataRow => new BookCard
                            {
                                Id = dataRow.Field<Guid>("Id"),
                                Title = dataRow.Field<string>("Title")
                            }).OrderBy(b => b.Title);
                }
                catch
                {
                    throw;
                    //TODO: add logging of exception
                }
            }
        }



    }
}