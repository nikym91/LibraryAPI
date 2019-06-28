using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int AuthorId { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
    }
}
