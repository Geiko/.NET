using LibraryBL.BookModels;
using LibraryBL.Providers;
using LibraryBL.Providers.Default;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Linq;
using NUnit.Framework.Internal;
using LibraryBL.ManagerModels.Default;

namespace LibraryBL.IntegrationTests
{
    [TestFixture]
    class LibrarianTest
    {
        IStorageProvider sqlProvider = new SqlStorageProvider(ConfigurationManager.ConnectionStrings["TestDB"].ToString());
        
        [Test]
        public void AddUserWithEmail()
        {
            //Arrange
            string testedEmail = "tested Email";
            Librarian librarian = new Librarian(sqlProvider);
            
            //Act
            bool isAdded = librarian.AddUser(testedEmail);
            bool isUserInDb = librarian.GetAllUsers().Any(u => u.Email.Equals(testedEmail));

            //Assert
            Assert.IsTrue(isAdded);
            librarian.RemoveUser(testedEmail);
            Assert.IsTrue(isUserInDb);
        }

        [Test]
        public void RegisterNewBookCardInt()
        {
            //Arrange
            string testedAuthorName1 = "some author1";
            string testedAuthorName2 = "some author2";
            string testedAuthorName3 = "some author3";
            string testedTitle = "some title";
            Author testedAuthor1 = new Author(testedAuthorName1);
            Author testedAuthor2 = new Author(testedAuthorName2);
            Author testedAuthor3 = new Author(testedAuthorName3);
            BookCard testedBookCard = new BookCard(testedTitle, testedAuthor1, testedAuthor2, testedAuthor3);
            Librarian librarian = new Librarian(sqlProvider);

            //Act
            bool isAdded = librarian.AddBook(testedBookCard);
            BookCard bookCard = librarian.GetBookCardById(testedBookCard.Id);

            //Assert
            Assert.IsTrue(isAdded);
            Assert.IsTrue(testedTitle.Equals(bookCard.Title));
            librarian.RemoveBookCard(testedBookCard.Id);
        }

        [Test]
        public void RegisterNewAuthorInt()
        {
            //Arrange
            string testedAuthorName = "tested Author Name";
            Author testedAuthor = new Author(testedAuthorName);
            Librarian librarian = new Librarian(sqlProvider);

            //Act
            bool isAdded = librarian.AddAuthor(testedAuthor);
            bool isAuthorInDb = librarian.GetAllAuthors().Any(u => u.Name.Equals(testedAuthorName));
            var author = librarian.GetAuthorById(testedAuthor.Id);

            //Assert
            Assert.IsTrue(isAdded);
            librarian.RemoveAuthor(author.Id);
            Assert.IsTrue(testedAuthorName.Equals(author.Name));
        }

        [Test]
        public void GetoutBookToUserInt()
        {
            //Arrange
            Guid testedBookCardId = Guid.NewGuid();
            string testedUserEmail = "testedUserEmail";
            Librarian librarian = new Librarian(sqlProvider);

            //Act
            bool isAdded = librarian.GetoutBook(testedBookCardId, testedUserEmail);
            bool isAuthorInDb = librarian.GetBookRecords(testedBookCardId)
                    .Any(r => ((r.UserEmail.Trim()).Equals(testedUserEmail)));

            //Assert
            Assert.IsTrue(isAdded);
            Assert.IsTrue(isAuthorInDb);
        }
    }
}
