using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.objects;
using DAL;




namespace LibraryDatabase
{
    class Program
    {
         
        static void Main(string[] args)
        {
            User userToAdd = new User();
            Console.WriteLine("Enter username");
            userToAdd.username = Console.ReadLine(); 

            Console.WriteLine("Enter password");
            userToAdd.password = Console.ReadLine();

            Console.WriteLine("Enter (1) = admin, (2) = mod, (3) = user");
            userToAdd.role_ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Press enter to begin");
            string userinput = Console.ReadLine();

            bool check = data4.
            if (addcheck == true)
            {
                Console.WriteLine("You have added a genre");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Failed to add genre");
                Console.ReadLine();
            }




            AuthorDataAccess data1 = new AuthorDataAccess();
            GenreDataAccess data2 = new GenreDataAccess();
            BookDataAccess data3 = new BookDataAccess();
            UserDataAccess data4 = new UserDataAccess();
            string done = "exit";
            while (done == "exit")
            {
                Console.WriteLine("Select a category: books, genre, author, exit");
                string category = Console.ReadLine().ToLower();


                if (category == "books")
                {
                    Console.WriteLine("What Would you like to do?");
                    Console.WriteLine("View books (V)?");
                    Console.WriteLine("Delete from the database (D)?");
                    Console.WriteLine("Add book (A)?");
                    Console.WriteLine("Update (U)?");

                    string choice = Console.ReadLine().ToUpper();

                    switch (choice)
                    {
                        case "V":
                            List<Books> BookToView = new List<Books>();
                            BookToView = data3.GetBooks();

                            foreach (Books singleBook in BookToView)
                            {
                                Console.WriteLine(singleBook.Book_ID + " " + singleBook.Book_title + " " + singleBook.Author_Name);
                            }
                            Console.ReadLine();
                            break;

                        case "D":
                            Console.WriteLine("Enter the ID of the book you would like to delete");


                            int deletechoice = Convert.ToInt32(Console.ReadLine());

                            Books deletebook = new Books();

                            deletebook.Book_ID = deletechoice;

                            bool check = data3.DeleteBook(deletebook);
                            if (check == true)
                            {
                                Console.WriteLine("You have deleted a book from the database");
                            }
                            else
                            {
                                Console.WriteLine("FAILED to delete");
                            }
                            break;

                        case "A":
                            Books bookToAdd = new Books();
                            Console.WriteLine("Enter title");
                            bookToAdd.Book_title = Console.ReadLine(); ;

                            Console.WriteLine("Enter book description");
                            bookToAdd.Book_descript = Console.ReadLine();

                            Console.WriteLine("Enter book price");
                            bookToAdd.Book_price = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Is the book paperback?");
                            bookToAdd.IsPaperback = Console.ReadLine();

                            Console.WriteLine("Enter Author ID");
                            bookToAdd.Author_ID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Genre ID");
                            bookToAdd.Genre_ID = Convert.ToInt32(Console.ReadLine());



                            bool addcheck = data3.NewBook(bookToAdd);
                            if (addcheck == true)
                            {
                                Console.WriteLine("You have added a book");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Failed to add book");
                                Console.ReadLine();
                            }

                            break;



                        case "U":
                            Books bookToUpdate = new Books();
                            Console.WriteLine("Enter book ID of the book you want to update");
                            bookToUpdate.Book_ID = (Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Enter title");
                            bookToUpdate.Book_title = Console.ReadLine(); ;

                            Console.WriteLine("Enter book description");
                            bookToUpdate.Book_descript = Console.ReadLine();

                            Console.WriteLine("Enter book price");
                            bookToUpdate.Book_price = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Is the book paperback?");
                            bookToUpdate.IsPaperback = Console.ReadLine();

                            Console.WriteLine("Enter Author ID");
                            bookToUpdate.Author_ID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Genre ID");
                            bookToUpdate.Genre_ID = Convert.ToInt32(Console.ReadLine());


                            bool updatecheck = data3.UpdateBook(bookToUpdate);
                            if (updatecheck == true)
                            {
                                Console.WriteLine("You have updated a book");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Failed to update book");
                                Console.ReadLine();
                            }

                            break;

                        default:
                            Console.Write("You have entered an invalid value");
                            Console.ReadLine();
                            break;




                    }
                }


                else if (category == "genre")
                {
                    Console.WriteLine("What Would you like to do?");
                    Console.WriteLine("View genres (V)?");
                    Console.WriteLine("Delete from the database (D)?");
                    Console.WriteLine("Add genre (A)?");
                    Console.WriteLine("Update (U)?");

                    string choice = Console.ReadLine().ToUpper();

                    switch (choice)
                    {
                        case "V":
                            List<Genres> GenreToView = new List<Genres>();
                            GenreToView = data2.GetGenres();

                            foreach (Genres singleGenre in GenreToView)
                            {
                                Console.WriteLine(singleGenre.Genre_ID + " " + singleGenre.Genre_Name + " " + singleGenre.Genre_descript);
                            }
                            Console.ReadLine();
                            break;

                        case "D":
                            Console.WriteLine("Enter the ID of the Genre you would like to delete");


                            int deletechoice = Convert.ToInt32(Console.ReadLine());

                            Genres deletegenre = new Genres();

                            deletegenre.Genre_ID = deletechoice;

                            bool check = data2.DeleteGenre(deletegenre);
                            if (check == true)
                            {
                                Console.WriteLine("You have deleted a genre from the database");
                            }
                            else
                            {
                                Console.WriteLine("FAILED to delete");
                            }
                            break;

                        case "A":
                            Genres genreToAdd = new Genres();
                            Console.WriteLine("Enter genre ID");
                            genreToAdd.Genre_ID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter genre name");
                            genreToAdd.Genre_Name = Console.ReadLine();

                            Console.WriteLine("Enter description");
                            genreToAdd.Genre_descript = (Console.ReadLine());

                            Console.WriteLine("Is the genre fiction?");
                            genreToAdd.IsFiction = Convert.ToBoolean(Console.ReadLine());





                            bool addcheck = data2.NewGenre(genreToAdd);
                            if (addcheck == true)
                            {
                                Console.WriteLine("You have added a genre");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Failed to add genre");
                                Console.ReadLine();
                            }

                            break;



                        case "U":
                            Genres genreToUpdate = new Genres();
                            Console.WriteLine("Enter genre ID of the genre you want to update");
                            genreToUpdate.Genre_ID = (Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Enter genre name");
                            genreToUpdate.Genre_Name = Console.ReadLine(); ;

                            Console.WriteLine("Enter genre description");
                            genreToUpdate.Genre_descript = Console.ReadLine();

                            Console.WriteLine("Enter genre description");
                            genreToUpdate.Genre_descript = Console.ReadLine();




                            bool updatecheck = data2.UpdateGenre(genreToUpdate);
                            if (updatecheck == true)
                            {
                                Console.WriteLine("You have updated a genre");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Failed to update genre");
                                Console.ReadLine();
                            }

                            break;

                        default:
                            Console.Write("You have entered an invalid value");
                            Console.ReadLine();
                            break;
                    }
                }
                else if (category == "author")
                {
                    Console.WriteLine("What Would you like to do?");
                    Console.WriteLine("View authors (V)?");
                    Console.WriteLine("Delete from the database (D)?");
                    Console.WriteLine("Add author (A)?");
                    Console.WriteLine("Update (U)?");

                    string choice = Console.ReadLine().ToUpper();

                    switch (choice)
                    {
                        case "V":
                            List<Authors> AuthorToView = new List<Authors>();
                            AuthorToView = data1.GetAuthors();

                            foreach (Authors singleAuthor in AuthorToView)
                            {
                                Console.WriteLine(singleAuthor.Author_ID + " " + singleAuthor.Author_Name + " " + singleAuthor.Author_Bio + " " + singleAuthor.Author_BirthLoc + " " + singleAuthor.Author_DOB);
                            }
                            Console.ReadLine();
                            break;

                        case "D":
                            Console.WriteLine("Enter the ID of the author you would like to delete");


                            int deletechoice = Convert.ToInt32(Console.ReadLine());

                            Authors deleteauthor = new Authors();

                            deleteauthor.Author_ID = deletechoice;

                            bool check = data1.DeleteAuthor(deleteauthor);
                            if (check == true)
                            {
                                Console.WriteLine("You have deleted an author from the database");
                            }
                            else
                            {
                                Console.WriteLine("FAILED to delete");
                            }
                            break;

                        case "A":
                            Authors authorToAdd = new Authors();
                            Console.WriteLine("Enter author ID");
                            authorToAdd.Author_ID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter author name");
                            authorToAdd.Author_Name = Console.ReadLine();

                            Console.WriteLine("Enter author bio");
                            authorToAdd.Author_Bio = (Console.ReadLine());

                            Console.WriteLine("Enter author birth location");
                            authorToAdd.Author_BirthLoc = Console.ReadLine();

                            Console.WriteLine("Enter author DOB");
                            authorToAdd.Author_DOB = Convert.ToDateTime(Console.ReadLine());





                            bool addcheck = data1.NewAuthor(authorToAdd);
                            if (addcheck == true)
                            {
                                Console.WriteLine("You have added an author");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Failed to add author");
                                Console.ReadLine();
                            }

                            break;



                        case "U":
                            Authors authorToUpdate = new Authors();
                            Console.WriteLine("Enter author ID of the author you want to update");
                            authorToUpdate.Author_ID = (Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Enter author name");
                            authorToUpdate.Author_Name = Console.ReadLine(); ;

                            Console.WriteLine("Enter author bio");
                            authorToUpdate.Author_Bio = Console.ReadLine();

                            Console.WriteLine("Enter author birth location");
                            authorToUpdate.Author_BirthLoc = Console.ReadLine();

                            Console.WriteLine("Enter author DOB");
                            authorToUpdate.Author_DOB = Convert.ToDateTime(Console.ReadLine());




                            bool updatecheck = data1.UpdateAuthor(authorToUpdate);
                            if (updatecheck == true)
                            {
                                Console.WriteLine("You have updated an author");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Failed to update author");
                                Console.ReadLine();
                            }

                            break;

                        default:
                            Console.Write("You have entered an invalid value");
                            Console.ReadLine();
                            break;
                    }
                }
                else if (category == "exit")
                {
                    done = "quit";
                }
                else
                {
                    Console.WriteLine("Failed to enter valid command");
                    Console.ReadLine();
                }



            }

            


        }


        
    }
}
