using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bibliotek
{
    public class BookSystem
    {
        private static BookSystem instance = null;
        private static string booksFilePath = @"C:\Users\tobias.nilsson13\biblioteket\biblioteket\Book.json";

        private List<Book> books = new List<Book>();

        public List<Book> GetBooks() { return books; }

        private BookSystem()
        {
            LoadBooks();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Save();
        }

        public void Save()
        {
            string booksJson = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(booksFilePath, booksJson);
        }

        public static BookSystem GetInstance()
        {
            if (instance == null)
            {
                instance = new BookSystem();
            }
            return instance;
        }

        public Book FindBook(string title)
        {
            Book book = books.FirstOrDefault(x => x.Subject == title);
            if (book != null)
            {
                Console.WriteLine($"Found book: {book.Subject} by {book.Author}");
                return book;
            }
            else
            {
                Console.WriteLine($"Book '{title}' not found.");
                return null;
            }
        }

            public void BorrowBook(string id)
        {
            Book? book = books.FirstOrDefault(x => x.Id == id);

            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                Save();
                Console.WriteLine($"Borrowed book {book.Id} - {book.Subject} by {book.Author}");
            }
            else
            {
                Console.WriteLine($"Book {id} is not available to borrow");
            }
        }

        public void ReturnBook(string id)
        {
            Book book = books.FirstOrDefault(x => x.Id == id);

            if (book != null && !book.IsAvailable)
            {
                book.IsAvailable = true;
                Save();
                Console.WriteLine($"Returned book {book.Id} - {book.Subject} by {book.Author}");
            }
            else
            {
                Console.WriteLine($"Book {id} is not borrowed or does not exist");
            }
        }

        void LoadBooks()
        {
            string data = File.ReadAllText(booksFilePath); 
            books = JsonConvert.DeserializeObject<List<Book>>(data);
        }
    }
}



