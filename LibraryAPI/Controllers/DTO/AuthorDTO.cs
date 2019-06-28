using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public Address Address { get; set; }
    }
}
