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

Also every Book has a button "Put it into my Cart". The buttons are disabled. To activate these b
uttons User should register his Email. There is also a button "Cart" in menu. This button allows 
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




