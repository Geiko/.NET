using LibraryBL.BookModels;
using LibraryBL.ManagerModels.Default;
using LibraryBL.Providers;
using LibraryBL.UserModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryBL
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

            //Act          
            bool result = librarian.AddBook(bookCard);
            var cards = librarian.GetCards(title, author);

            //Assert
            Assert.IsTrue(result);
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
            mockProvider
                .Setup(i => i.AddBookCards(increment, title, author))
                .Returns(true);
            mockProvider
                .Setup(i => i.GetBookCards(title, new Author[] { author }))
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
            Guid bookCardId = Guid.NewGuid();
            //List<BookCard> cards = new List<BookCard>
            //{
            //    new BookCard {Id = Guid.NewGuid(), Title = "some title 1" },
            //    new BookCard {Id = bookCardId, Title = "some title 2" },
            //    new BookCard {Id = Guid.NewGuid(), Title = "some title 3" }
            //};

            //BookCard bookCardToDelete = cards.Single(c => c.Id == bookCardId);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider
                .Setup(i => i.RemoveBookCard(bookCardId))
                //.Callback(() => cards.Remove(bookCardToDelete))
                .Returns(true);
            //mockProvider.Setup(i => i.GetAllBookCards()).Returns(cards);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            //var allCards = librarian.GetAllBookCards();
            bool result = librarian.RemoveBookCard(bookCardId);

            //Assert
            Assert.IsTrue(result);
            //Assert.IsFalse(allCards.Any(c => c.Id == bookCardId));
        }



        [Test]
        public void RegisterNewUser()
        {
            //Arrange
            string email = "some email";
            List<User> users = new List <User>
            {
                new User { Email= "some email 1" },
                new User { Email= "some email 2" },
            };

            var expectedUser = new User(email);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider
                .Setup(i => i.AddUser(email))
                .Callback(() => users.Add(expectedUser))
                .Returns(true);
            mockProvider
                .Setup(i => i.GetAllUsers())
                .Returns(users);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            bool result = librarian.AddUser(email);
            var allUsers = librarian.GetAllUsers();
            var user = allUsers.Single(u => u.Email == email);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedUser, user);
        }


        [Test]
        public void RemoveUserByEmail()
        {
            //Arrange
            string email = "some email";
            List<User> users = new List<User>
            {
                new User { Email= "some email 1" },
                new User { Email= "some email 2" },
                new User { Email= email }
            };

            var userToDelete = users.Single(u => u.Email == email);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider
                .Setup(i => i.RemoveUser(email))
                .Callback(() => users.Remove(userToDelete))
                .Returns(true);
            mockProvider.Setup(i => i.GetAllUsers()).Returns(users);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            bool result = librarian.RemoveUser(email);
            var allUsers = librarian.GetAllUsers();
            int userQuantity = allUsers.Where(u => u.Email == email).Count();

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, userQuantity);
        }



        [Test]
        public void UpdateUser()
        {
            //Arrange
            string oldEmail = "email to update";
            string newEmail = "new email";
            List<User> users = new List<User>
            {
                new User { Email = "some email 1" },
                new User { Email = "some email 2" },
                new User { Email = oldEmail }
            };
            
            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider
                .Setup(i => i.UpdateUser(oldEmail, newEmail))
                .Callback(() => users.Single(u => u.Email == oldEmail).Email = newEmail)
                .Returns(true);
            mockProvider.Setup(i => i.GetAllUsers()).Returns(users);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            bool result = librarian.UpdateUser(oldEmail, newEmail);
            var allUsers = librarian.GetAllUsers();
            int emailQuantity = allUsers.Where(u => u.Email.Equals(oldEmail)).Count();
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

            List<BookCard> testedBookCards = new List<BookCard>
            {
                new BookCard { Id = bookId, Records = new List<Record> { } },
                new BookCard { Id = Guid.NewGuid(), Records = new List<Record> { } },
                new BookCard { Id = Guid.NewGuid(), Records = new List<Record> { } }
            };

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider
                .Setup(i => i.GetoutBook(bookId, userId))
                .Callback(() => (testedBookCards.Single(b => b.Id == bookId)).Records.Add(record))
                .Returns(true);
            mockProvider
                .Setup(i => i.GetRecords(bookId))
                .Returns(testedBookCards.Single(b => b.Id == bookId).Records);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            bool result = librarian.GetoutBook(bookId, userId);
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
            Record record = new Record
            {
                GetoutTime = new DateTime(2000, 5, 22),
                ReturnTime = null
            };

            List<BookCard> testedBookCards = new List<BookCard>
            {
                new BookCard { Id = bookId, Records = new List<Record> { record } },
                new BookCard { Id = Guid.NewGuid(), Records = new List<Record> { } },
                new BookCard { Id = Guid.NewGuid(), Records = new List<Record> { } }
            };
            
            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider
                .Setup(i => i.ReturnBook(bookId))
                .Callback(() => (testedBookCards
                                    .Single(b => b.Id == bookId)
                                    .Records.Single(r => r.ReturnTime == null))
                                    .ReturnTime = returnTime)
                .Returns(true);
            mockProvider
                .Setup(i => i.GetRecords(bookId))
                .Returns(testedBookCards.Single(b => b.Id == bookId).Records);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            bool result = librarian.ReturnBook(bookId);
            IEnumerable<Record> bookRecords = librarian.GetBookRecords(bookId);
            IEnumerable<DateTime?> returnTimes = bookRecords.Select(r => r.ReturnTime);
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
            var areAvailable = availableBooks.Where(b => b.Records != null)
                                            .SelectMany(b => b.Records)
                                            .All(rec => rec.ReturnTime != null);
            //Assert
            Assert.NotNull(availableBooks);
            Assert.IsTrue(areAvailable);
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
            Assert.NotNull(takenBooks);
            Assert.IsTrue(isTaken);
        }



        [Test]
        public void GetUserRecords()
        {
            //Arrange
            int userId = 333;
            IEnumerable<Record> testedUserRecords = getTestedRecordes(userId);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.GetUserRecords(userId)).Returns(testedUserRecords);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            IEnumerable<Record> userRecords = librarian.GetUserRecords(userId);
            var areUserIdsCorrect = userRecords.All(r => r.UserId == userId);

            //Assert
            Assert.NotNull(userRecords);
            Assert.IsTrue(areUserIdsCorrect);
        }



        [Test]
        public void GetBookRecords()
        {
            //Arrange
            Guid bookCardId = Guid.NewGuid();
            IEnumerable<Record> testedBookRecords = getTestedRecordes(bookCardId);

            var mockProvider = new Moq.Mock<IStorageProvider>();
            mockProvider.Setup(i => i.GetRecords(bookCardId)).Returns(testedBookRecords);

            Librarian librarian = new Librarian(mockProvider.Object);

            //Act
            IEnumerable<Record> bookCardRecords = librarian.GetBookRecords(bookCardId);
            var isBookCardIdCorrect = bookCardRecords.All(r => r.BookCardId == bookCardId);

            //Assert
            Assert.NotNull(bookCardRecords);
            Assert.IsTrue(isBookCardIdCorrect);
        }
        
        //  Private methods ---------------------------------------------------------------

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
                            ReturnTime = new DateTime(2017, 2, 18)
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
                            ReturnTime = new DateTime(2017, 2, 16)
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



        private IEnumerable<Record> getTestedRecordes(int userId)
        {
            return new List<Record>
            {
                new Record
                {
                    UserId = userId,
                    BookCardId = Guid.NewGuid(),
                    GetoutTime = new DateTime(2013, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = userId,
                    BookCardId = Guid.NewGuid(),
                    GetoutTime = new DateTime(2013, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = userId,
                    BookCardId = Guid.NewGuid(),
                    GetoutTime = new DateTime(2014, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = userId,
                    BookCardId = Guid.NewGuid(),
                    GetoutTime = new DateTime(2014, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = userId,
                    BookCardId = Guid.NewGuid(),
                    GetoutTime = new DateTime(2015, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = userId,
                    BookCardId = Guid.NewGuid(),
                    GetoutTime = new DateTime(2016, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = userId,
                    BookCardId = Guid.NewGuid(),
                    GetoutTime = new DateTime(2017, 05, 25),
                    ReturnTime = null
                }
            };
        }



        private IEnumerable<Record> getTestedRecordes(Guid bookCardId)
        {
            return new List<Record>
            {
                new Record
                {
                    UserId = 235,
                    BookCardId = bookCardId,
                    GetoutTime = new DateTime(2013, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = 6522,
                    BookCardId = bookCardId,
                    GetoutTime = new DateTime(2013, 05, 25),
                    ReturnTime = new DateTime(2013, 06, 1)
                },
                new Record
                {
                    UserId = 864,
                    BookCardId = bookCardId,
                    GetoutTime = new DateTime(2014, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = 845,
                    BookCardId = bookCardId,
                    GetoutTime = new DateTime(2014, 05, 25),
                    ReturnTime = new DateTime(2017, 08, 22)
                },
                new Record
                {
                    UserId = 85,
                    BookCardId = bookCardId,
                    GetoutTime = new DateTime(2015, 05, 25),
                    ReturnTime = new DateTime(2015, 07, 2)
                },
                new Record
                {
                    UserId = 151,
                    BookCardId = bookCardId,
                    GetoutTime = new DateTime(2016, 05, 25),
                    ReturnTime = null
                },
                new Record
                {
                    UserId = 897,
                    BookCardId = bookCardId,
                    GetoutTime = new DateTime(2017, 05, 25),
                    ReturnTime = null
                }
            };
        }
    }
}
