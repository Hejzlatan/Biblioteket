using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Search
    {
        static BookSystem system = BookSystem.GetInstance();

        public static void SearchPage()
        {
            // raderar historiken i terminalen (ascii erase display)
            Console.WriteLine("\u001b[2J\u001b[3J");
            Book book = null;
            while (true)
            {
                Console.Write("Sök efter en bok: ");
                var query = Console.ReadLine();
                Console.WriteLine("\n");

                // raderar historiken i terminalen (ascii erase display)
                Console.WriteLine("\u001b[2J\u001b[3J");
                Console.Clear();


                Console.WriteLine($"Sök efter en bok: {query}\n");

                 book = system.FindBook(query);

                if(book != null)
                {
                    Console.WriteLine($"Id: {book.Id}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Subject:{book.Subject}");
                    Console.WriteLine($"Price: {book.Price}\n");

                    // Visa meny för att låna eller lämna tillbaka bok
                    Console.WriteLine("Vad vill du göra?");
                    Console.WriteLine("1. Låna bok");
                    Console.WriteLine("2. Lämna tillbaka bok");
                    Console.Write("Ange ditt val: ");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        // användaren vill låna boken
                        Console.Write("Ange bokens ID: ");
                        string bookId = Console.ReadLine();
                        system.BorrowBook(bookId);
                    }
                    else if (input == "2")
                    {
                        // användaren vill lämna tillbaka boken
                        Console.Write("Ange bokens ID: ");
                        string bookId = Console.ReadLine();
                        system.ReturnBook(bookId);
                    }
                    else
                    {
                        // ogiltigt val
                        Console.WriteLine("Ogiltigt val");
                    }

                    // Avsluta sök-loopen efter att sökresultatet har skrivits ut
                    break;
                }
                
            }

        }



    }
}




