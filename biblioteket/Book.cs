using System;

namespace Bibliotek
{
    public class Book
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Subject { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string id, string author, decimal price, string subject, bool isAvailable)
        {
            Id = id;
            Author = author;
            Price = price;
            Subject = subject;
            IsAvailable = isAvailable;
        }
    }
}

