using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Models;

namespace LibraryDomainTests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void RegisterNewBook()
        {
            BookRecord book = new BookRecord();

            bool success = Library.LibraryRegistrator.AddBook(book);

            IEnumerable<RegistrationCards> cards =  Library.LibraryRegistrator.GetCards(book);

            Assert.IsTrue(success);
            Assert.AreEqual(1, cards.Count() );
        }


        [Test]
        public void RegisterNewBookTwice()
        {
            //Arrange

            BookRecord book = new BookRecord();

            bool success = Library.LibraryRegistrator.AddBook(book, 3);

            //Act
            Action testDelegate = () =>
            {
                var success2 = Library.LibraryRegistrator.AddBook(book);
            };

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<Exception>());
        }

        [Test]
        public void AddOneMoreBookToLibraryById()
        {
            string author = "";
            string title = "";

            BookRecord bookRecord = Library.LibraryRegistrator.GetBookRecord(author, title);

            Guid? bookId = Library.LibraryRegistrator.AddBook(bookRecord.Id);

            Assert.IsNotNull(bookId);
        }
    }
}
