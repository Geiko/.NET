using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryDomainTests
{
    [TestFixture]
    public class Test
    {

        LibraryRegistrator registrator = new LibraryRegistrator();

        [Test]
        public void RegisterNewBook()
        {
            //Arrange
            BookRecord book = new BookRecord();

            //Act
            bool success = registrator.AddBook(book);
            IEnumerable<RegistrationCards> cards = registrator.GetCards(book);

            //Assert
            Assert.IsTrue(success);
            Assert.AreEqual(1, cards.Count() );
        }



        [Test]
        public void RegisterNewBookTwice()
        {
            //Arrange
            BookRecord book = new BookRecord();
            bool success = registrator.AddBook(book, 3);

            //Act
            Action testDelegate = () =>
            {
                var success2 = registrator.AddBook(book);
            };

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<Exception>());
        }



        [Test]
        public void AddOneMoreBookToLibraryById()
        {
            //Arrange
            string author = "";
            string title = "";

            //Act
            BookRecord book = registrator.GetBookRecord(author, title);
            Guid? bookId = registrator.AddBook(book.Id);

            //Assert
            Assert.IsNotNull(bookId);
        }

        //--------------------------------------

        [Test]
        public void RemoveBookById()
        {
            //Arrange
            string author = "";
            string title = "";

            //Act
            BookRecord book = registrator.GetBookRecord(author, title);
            bool success = registrator.DeleteBook(book.Id);

            //Assert
            Assert.IsTrue(success);
        }



        [Test]
        public void ChangeBookQuantityById()
        {
            //Arrange
            string author = "";
            string title = "";
            int increment = -1;

            //Act
            BookRecord book = registrator.GetBookRecord(author, title);
            IEnumerable<RegistrationCards> cards = registrator.GetCards(book);
            bool success = registrator.ChangeBookQuantity(book.Id, increment);
            IEnumerable<RegistrationCards> updatedCards = registrator.GetCards(book);

            //Assert
            Assert.IsTrue(success);
            Assert.AreEqual(cards.Count() + increment, updatedCards.Count());
        }



        [Test]
        public void GetoutBook()
        {
            //Arrange
            //Act
            //Assert
        }



        [Test]
        public void ReturnBook()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
