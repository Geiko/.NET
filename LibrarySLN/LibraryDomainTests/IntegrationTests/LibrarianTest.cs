using LibraryBL.BookModels;
using LibraryBL.Providers;
using LibraryBL.UserModels;
using LibraryBL.Providers.Default;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        public void RegisterNewBookCard()
        {
            //Arrange
            string authorName = "some author";
            string title = "some title";
            Author author = new Author(authorName);
            BookCard bookCard = new BookCard(title, author);

            Librarian librarian = new Librarian(sqlProvider);
            librarian.AddBook(bookCard);

            //Act
            var cards = librarian.GetCards(title, author);

            //Assert
            Assert.AreEqual(bookCard.Id, cards.First().Id);
        }



        [Test]
        public void AddUserWithEmail()
        {
            //Arrange
            string testedEmail = "tested Email";
            //var expectedUser = new User(testedEmail);

            Librarian librarian = new Librarian(sqlProvider);
            var x = librarian.AddUser(testedEmail);
            
            //Act
            bool result = librarian.AddUser(testedEmail);
            //var allUsers = librarian.GetAllUsers();
            //var users = allUsers.Where(u => u.Email == testedEmail);

            //Assert
            Assert.IsTrue(result);
            //Assert.AreEqual(1, users);
        }
    }
}
