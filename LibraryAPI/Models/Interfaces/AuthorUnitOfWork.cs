using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Interfaces
{
    public interface AuthorUnitOfWork
    {
        IQueryable<Author> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task UpdateAddress(Address address);
        Task<bool> SaveChangesAsync();
        Task AddAuthorAsync(Author author);
        Task DeleteAuthor(Author author);
        bool AuthorExist(int id);
    }
}
