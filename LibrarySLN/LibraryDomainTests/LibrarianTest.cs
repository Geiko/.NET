using LibraryBL.BookModels;
using LibraryBL.ManagerModels;
using LibraryBL.UserModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryDomainTests
{
    [TestFixture]
    class LibrarianTest
    {        
        [Test]
        public void RegisterNewBookCard()
        {
            //Arrange
            string authorName = "some author";
            string title = "some title";
            Author author = new Author(authorName);
            BookCard bookCard = new BookCard(title, author);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.AddBookCard(bookCard)).Returns(true);
            mockProvider.Setup(i => i.GetBookCards(title, new Author[] { author }))
                .Returns(new BookCard[] { bookCard });    
                    
            Librarian librarian = new Librarian(mockProvider.Object);            
            librarian.AddBook(bookCard);

            //Act
            var cards = librarian.GetCards(title, author);

            //Assert
            Assert.AreEqual(bookCard.Id, cards.First().Id);
        }



        [Test]
        public void RegisterSeveralInstanceOfNewBookCards()
        {
            //Arrange
            string authorName = "some author";
            string title = "some title";
            int increment = 3;
            Author author = new Author(authorName);
            BookCard[] bookCards = new BookCard[] 
            {
                new BookCard(title, author),
                new BookCard(title, author),
                new BookCard(title, author)
            };

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.AddBookCards(increment, title, author))
                .Returns(true);
            mockProvider.Setup(i => i.GetBookCards(title, new Author[] { author }))
                .Returns(bookCards);

            Librarian librarian = new Librarian(mockProvider.Object);
            bool result = librarian.AddBooks(increment, title, author);

            //Act
            var cards = librarian.GetCards(title, author);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(increment, cards.Count());
        }



        [Test]
        public void RemoveBookCardById()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            IEnumerable<BookCard> cards = new List<BookCard>
            {
                new BookCard {Id = Guid.NewGuid(), Title = "some title 1" },
                new BookCard {Id = Guid.NewGuid(), Title = "some title 2" },
                new BookCard {Id = Guid.NewGuid(), Title = "some title 3" }
            };            

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.RemoveBookCard(id)).Returns(true);
            mockProvider.Setup(i => i.GetAllBookCards()).Returns(cards);

            Librarian librarian = new Librarian(mockProvider.Object);
            bool result = librarian.RemoveBookCard(id);

            //Act
            var allCards = librarian.GetAllBookCards();

            //Assert
            Assert.IsTrue(result);
            Assert.IsFalse(cards.Any(c => c.Id == id));
        }



        [Test]
        public void RegisterNewUser()
        {
            //Arrange
            string email = "some email";
            Guid id = Guid.NewGuid();
            IEnumerable<User> users = new List <User>
            {
                new User { Email= "some email 1" },
                new User { Email= "some email 2" },
                new User { Email= "some email" }
            };

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.AddUser(email)).Returns(true);
            mockProvider.Setup(i => i.GetAllUsers()).Returns(users);

            Librarian librarian = new Librarian(mockProvider.Object);
            bool result = librarian.AddUser(email);

            //Act
            var allUsers = librarian.GetAllUsers();
            allUsers.Single(u => u.Email.Equals(email));

            //Assert
            Assert.IsTrue(result);
        }


        [Test]
        public void RemoveUserByEmail()
        {
            //Arrange
            string email = "some email";
            IEnumerable<User> users = new List<User>
            {
                new User { Email= "some email 1" },
                new User { Email= "some email 2" },
                new User { Email= "some email 3" }
            };

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.RemoveUser(email)).Returns(true);
            mockProvider.Setup(i => i.GetAllUsers()).Returns(users);

            Librarian librarian = new Librarian(mockProvider.Object);
            bool result = librarian.RemoveUser(email);

            //Act
            var allUsers = librarian.GetAllUsers();
            int userQuantity = allUsers.Where(u => u.Email.Equals(email)).Count();
            //Action testDelegate = () =>
            //{
            //   var x = allUsers.First(u => u.Email.Equals(email));
            //};

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, userQuantity);
            //Assert.That(testDelegate, Throws.TypeOf<Exception>());
        }



        [Test]
        public void UpdateUser()
        {
            //Arrange
            string email = "some email";
            string newEmail = "some new email";
            IEnumerable<User> users = new List<User>
            {
                new User { Email= "some email 1" },
                new User { Email= "some email 2" },
                new User { Email= "some new email" }
            };

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.UpdateUser(email, newEmail)).Returns(true);
            mockProvider.Setup(i => i.GetAllUsers()).Returns(users);

            Librarian librarian = new Librarian(mockProvider.Object);
            bool result = librarian.UpdateUser(email, newEmail);

            //Act
            var allUsers = librarian.GetAllUsers();
            int emailQuantity = allUsers.Where(u => u.Email.Equals(email)).Count();
            int newEmailQuantity = allUsers.Where(u => u.Email.Equals(newEmail)).Count();

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, emailQuantity);
            Assert.AreEqual(1, newEmailQuantity);
        }



        [Test]
        public void GetoutBookToUser()
        {
            //Arrange
            Guid bookId = Guid.NewGuid();
            int userId = 38;
            DateTime getoutTime = DateTime.Now;
            DateTime? returnTime = null;
            Record record = new Record
            {
                UserId = userId,
                GetoutTime = getoutTime,
                ReturnTime = returnTime
            };

            IEnumerable<Record> records = getRecords(record);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.GetoutBook(bookId, userId)).Returns(true);
            mockProvider.Setup(i => i.GetRecords(bookId)).Returns(records);

            Librarian librarian = new Librarian(mockProvider.Object);
            bool result = librarian.GetoutBook(bookId, userId);

            //Act
            IEnumerable<Record> bookRecords = librarian.GetBookRecords(bookId);

            int recordQuantity = bookRecords.Where(r => r.Equals(record)).Count();

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, recordQuantity);
        }



        [Test]
        public void ReturnBookFromUser()
        {
            //Arrange
            Guid bookId = Guid.NewGuid();
            DateTime? returnTime = DateTime.Now;

            IEnumerable<Record> records = getRecords(returnTime);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.ReturnBook(bookId)).Returns(true);
            mockProvider.Setup(i => i.GetRecords(bookId)).Returns(records);

            Librarian librarian = new Librarian(mockProvider.Object);
            bool result = librarian.ReturnBook(bookId);

            //Act
            IEnumerable<Record> bookRecords = librarian.GetBookRecords(bookId);
            IEnumerable<DateTime?> returnTimes = records.Select(r => r.ReturnTime);
            returnTimes.Single(rt => DateTime.Compare((DateTime)rt, (DateTime)returnTime) == 0);

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(returnTimes.All(rt => rt != null));
        }



        [Test]
        public void GetAvailableBook()
        {
            //Arrange
            IEnumerable<BookCard> bookCards = getAvailableBookCards();

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.GetAvailableBookCards()).Returns(bookCards);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            IEnumerable<BookCard> availableBooks = librarian.GetAvailableBookCards();
            var isAvailable = availableBooks.Where(b => b.Records != null)
                                            .SelectMany(b => b.Records)
                                            .All(rec => rec.ReturnTime != null);
            //Assert
            Assert.IsTrue(isAvailable);
        }



        [Test]
        public void GetTakenBooks()
        {
            //Arrange
            IEnumerable<BookCard> bookCards = getTakenBookCards();

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.GetTakenBookCards()).Returns(bookCards);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            IEnumerable<BookCard> takenBooks = librarian.GetTakenBookCards();
            var isTaken = takenBooks.All(b => b.Records.Any(rec => rec.ReturnTime == null));

            //Assert
            Assert.IsTrue(isTaken);
        }



        private IEnumerable<Record> getRecords(Record record)
        {
            return new List<Record>()
            {
                new Record
                {
                    UserId = 3,
                    GetoutTime = new DateTime(2015, 1, 15),
                    ReturnTime = new DateTime(2015, 1, 16)
                },
                new Record
                {
                    UserId = 33,
                    GetoutTime = new DateTime(2016, 1, 15),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = record.UserId,
                    GetoutTime = record.GetoutTime,
                    ReturnTime = record.ReturnTime
                }
            };
        }



        private IEnumerable<Record> getRecords(DateTime? returnTime)
        {
            return new List<Record>()
            {
                new Record
                {
                    UserId = 3,
                    GetoutTime = new DateTime(2015, 1, 15),
                    ReturnTime = new DateTime(2015, 1, 17)
                },
                new Record
                {
                    UserId = 33,
                    GetoutTime = new DateTime(2016, 1, 15),
                    ReturnTime = new DateTime(2016, 2, 15)
                },
                new Record
                {
                    UserId = 33,
                    GetoutTime = new DateTime(2017, 1, 16),
                    ReturnTime = returnTime
                }
            };
        }



        private IEnumerable<BookCard> getAvailableBookCards()
        {
            return new List<BookCard>
            {
                new BookCard
                {
                    Records = new List<Record>{ }
                },
                new BookCard
                {
                    Records = new List<Record>
                    {
                        new Record
                        {
                            UserId = 3,
                            GetoutTime = new DateTime(2015, 1, 15),
                            ReturnTime = new DateTime(2015, 1, 17)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2016, 1, 15),
                            ReturnTime = new DateTime(2016, 2, 15)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2017, 1, 16),
                            ReturnTime = new DateTime(2017, 2, 15)
                        }

                    }
                },
                new BookCard
                {
                    Records = new List<Record>
                    {
                        new Record
                        {
                            UserId = 3,
                            GetoutTime = new DateTime(2015, 1, 15),
                            ReturnTime = new DateTime(2015, 1, 17)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2016, 1, 15),
                            ReturnTime = new DateTime(2016, 2, 15)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2017, 1, 16),
                            ReturnTime = new DateTime(2017, 2, 15)
                        }

                    }
                },
                new BookCard
                {
                    Records = new List<Record>
                    {
                        new Record
                        {
                            UserId = 3,
                            GetoutTime = new DateTime(2015, 1, 15),
                            ReturnTime = new DateTime(2015, 1, 17)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2016, 1, 15),
                            ReturnTime = new DateTime(2016, 2, 15)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2017, 1, 16),
                            ReturnTime = new DateTime(2017, 2, 15)
                        }
                    }
                }
            };
        }



        private IEnumerable<BookCard> getTakenBookCards()
        {
            return new List<BookCard>
            {
                new BookCard
                {
                    Records = new List<Record>
                    {
                        new Record
                        {
                            UserId = 3,
                            GetoutTime = new DateTime(2015, 1, 15),
                            ReturnTime = new DateTime(2015, 1, 17)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2016, 1, 15),
                            ReturnTime = new DateTime(2016, 2, 15)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2017, 1, 16),
                            ReturnTime = null
                        }

                    }
                },
                new BookCard
                {
                    Records = new List<Record>
                    {
                        new Record
                        {
                            UserId = 3,
                            GetoutTime = new DateTime(2015, 1, 15),
                            ReturnTime = new DateTime(2015, 1, 17)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2016, 1, 15),
                            ReturnTime = new DateTime(2016, 2, 15)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2017, 1, 16),
                            ReturnTime = null
                        }

                    }
                },
                new BookCard
                {
                    Records = new List<Record>
                    {
                        new Record
                        {
                            UserId = 3,
                            GetoutTime = new DateTime(2015, 1, 15),
                            ReturnTime = new DateTime(2015, 1, 17)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2016, 1, 15),
                            ReturnTime = new DateTime(2016, 2, 15)
                        },
                        new Record
                        {
                            UserId = 33,
                            GetoutTime = new DateTime(2017, 1, 16),
                            ReturnTime = null
                        }
                    }
                }
            };
        }
    }
}
