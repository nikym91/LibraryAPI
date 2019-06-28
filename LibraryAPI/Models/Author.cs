using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public Address Address { get; set; }

        public Author() { }

        public Author(int authorId, string name, string username, Address address)
        {
            AuthorId = authorId;
            Name = name;
            Username = username;
            Address = address;
        }
    }
}
