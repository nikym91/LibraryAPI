using AutoMapper;
using LibraryAPI.Controllers.DTO;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            this.CreateMap<Book, BookDTO>()
                .ReverseMap();
        }
    }
}
