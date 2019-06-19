using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task6__Library_
{
    class Program
    {
        private static List<Book> books = new List<Book>();
        private static List<Book> hands = new List<Book>();

        static void Main(string[] args)
        {
            bool flag = true;
            Console.WriteLine("Menu:\n1) Add a new book;\n2) Show all available books;\n3) Show books on hands;\n4) Take a book;\n5) Return a book;\n6) Delete book;\n7) Exit.");
            while(flag)
            {
                switch(Console.ReadLine())
                {
                    case "add":
                        Console.WriteLine("Enter Author and book name:");
                        string line = Console.ReadLine();
                        bool duplicate = false;
                        if (line != null)
                        {
                            string[] temp = line.Split(',');
                            AddB(temp[0], temp[1]);

                            //if (books.Count < 1)
                            //{
                            //    AddB(temp[0], temp[1]);                                
                            //}
                            //else
                            //{
                            //    foreach (Book book in books.ToArray())
                            //    {
                            //        if (book.BName == temp[1])
                            //        {
                            //            Console.WriteLine("\nthis book has already added.\n");
                            //            duplicate = true;
                            //            break;
                            //        }
                            //    }

                            //    if (duplicate == false)
                            //    {
                            //        AddB(temp[0], temp[1]);
                            //    }
                            //}
                        }
                        break;
                    case "all":
                        SeeAll();
                        break;
                    case "hands":
                        SeeHands();
                        break;
                    case "take":
                        Take();
                        break;
                    case "return":
                        Return();
                        break;
                    case "delete":
                        Delete();
                        break;
                    case "exit":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect command. Try again.\n");
                        break;
                }

            }
        }

        private static void AddB(string author, string bname)
        {
            books.Add(new Book(author, bname));
            Console.WriteLine("The book was successfully added\n");
        }

        private static void AddH(string author, string bname)
        {
            hands.Add(new Book(author, bname));
        }

        private static void Take()
        {
            string str1,str2 = null;
            Console.WriteLine("Enter book name which you want to take: ");
            str1 = Console.ReadLine();

            foreach (Book book in books.ToArray())
            {
                if (book.BName == str1)
                {
                    AddH(book.Author, book.BName);
                    books.Remove(book);
                    str2 = str1;
                    break;
                }                
            }

            if (String.IsNullOrEmpty(str2) == true)
            {
                Console.WriteLine("\nThere is no such book.\n");
            }
        }

        private static void Return()
        {
            string str1, str2 = null;
            Console.WriteLine("Enter book name which you want to return: ");
            str1 = Console.ReadLine();

            foreach (Book book in hands.ToArray())
            {
                if (book.BName == str1)
                {
                    AddB(book.Author, book.BName);
                    hands.Remove(book);
                    str2 = str1;
                    break;
                }
            }

            if (String.IsNullOrEmpty(str2) == true)
            {
                Console.WriteLine("\nYou don't have this book.\n");
            }
        }

        private static void Delete()
        {
            string str1, str2 = null;
            Console.WriteLine("Enter book name which you want to delete: ");
            str1 = Console.ReadLine();

            foreach (Book book in books.ToArray())
            {
                if (book.BName == str1)
                {                    
                    books.Remove(book);
                    str2 = str1;
                    break;
                }
            }

            if (String.IsNullOrEmpty(str2) == true)
            {
                Console.WriteLine("\nThere is no such book.\n");
            }
        }

        private static void SeeAll ()
        {
            foreach (Book book in books)
            {
                Console.WriteLine("Author: {0}, Book: {1}\n", book.Author, book.BName);
            }
        }

        private static void SeeHands()
        {
            foreach (Book book in hands)
            {
                Console.WriteLine("Author: {0}, Book: {1}\n", book.Author, book.BName);
            }
        }
    }

    class Book
    {
        public string Author { get; set; }
        public string BName { get; set; }

        public Book (string author, string bname)
        {
            this.Author = author;
            this.BName = bname;
        }
    }
}
