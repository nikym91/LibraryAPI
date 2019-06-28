using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int AuthorId { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }

        public Book() { }

        public Book(int bookId, string title, string subtitle, int authorId, string publisher, int pages, string description)
        {
            BookId = bookId;
            Title = title;
            Subtitle = subtitle;
            AuthorId = authorId;
            Publisher = publisher;
            Pages = pages;
            Description = description;
        }
    }
}
