Task description: Implement simplified version of a Library application. 

The application should provide the following functionality:
•	managing books available in the library: adding, removing, changing quantity. Each book can have a few authors, an author can write a few books.
•	a book can be taken by different people and at different time;
•	registration is required to take books. User should be able to register himself. Password is not necessary, but email is (i.e. strong security protection is not necessary for this task);
•	Implement filter that shows all books / books available / books taken by the user.
•	library tracks its readers (users). Show a history of a book (when and by whom was taken)
•	implement sending notifications by mail to people who took a book (“You took the following books in our library”)

Delivery: GitHub repository, containing: 
•	source code ready to be compiled and run
•	backup or detached files of the database
•	Installation guide and small User Guide in English

Estimated implementation time: ~8-10 hours

Important note: essential requirements for the task are algorithm, idea you try to implement, using the most efficient way and code. UI Design is not so important, though accuracy is.

Implementation requirements:
1.	ASP.NET MVC Application
2.	Library UI is a web application, which has a front-end page with grid. Grid should allow paging, sorting by book titles and author names. No complex design required.
3.	Minimize number of post backs.
4.	You must not use an existing ORM like Entity Framework, NHibernate etc. for working with the database.

Note: The test task is only a starting point for the conversation we’ll have during the interview. You should not try to use all the technologies / practices / patterns you outlined in your CV; you should not try to make this test task more complex than it’s necessary. We’d like to see a piece of code as you would do your daily working task.


30.03.2017

Applicant: Kostiantyn Geiko
Position: .Net Trainee


Installation guide:

Library Application is located on GitHub: https://github.com/Geiko/.NET/tree/master/LibrarySLN

To install it, it is needed to be cloned into a client computer. 
Then, run the following file D:\MyFolder\.NET\LibrarySLN\LibrarySLN.sln. 
The application will be opened in Visual Studio.


User guide:

User can see list of Books on the main page of application. There are:
	- Title;
	- dropDown list of Authors ;
	- checkbox that shows is the Book available to borrow for every book there.
There are radiobuttons filtering and sorting books. 
There is Paginator there, that shows only 5 book instances on a page. 

Also every Book has a button "Put it into my Cart". The buttons are disabled. To activate these 
buttons User should register his Email. There is also a button "Cart" in menu. This button allows 
to see books that User is going to borrow from library and to send the book list to a librarian. 
Librarian panel has link "Orders" where books can be registered. This service is not implemented yet, 
because there is no requirement fot it. That is created just to propel a User to register his Email.

There is a button "Librarian" in menu. Librarian manages the library, he is an administrator.
CRUD operation with Books, Users and Authors are implemented for Librarian panel.
Librarian can Getout a book to a User (Librarian / BookCard / Getout) and Return a book 
(Librarian / BookCard / Return).
After getting out a Book, a message is sent to the User. If credentials for some mail account would 
be added into the code, this service will work. This feature has been tested with developer credentials.
Librarian panel allows to see User history, Book history, and all books of an Author 
that exists in the Library.




