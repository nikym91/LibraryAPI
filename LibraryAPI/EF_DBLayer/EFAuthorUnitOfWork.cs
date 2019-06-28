using LibraryAPI.Models;
using LibraryAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.EF_DBLayer
{
    public class EFAuthorUnitOfWork : AuthorUnitOfWork
    {
        private readonly AuthorRepository AuthorRepository;

        public EFAuthorUnitOfWork(AuthorRepository repo)
        {
            AuthorRepository = repo;
        }

        public async Task AddAuthorAsync(Author author)
        {
            await AuthorRepository.AddAuthorAsync(author);
        }

        public bool AuthorExist(int id)
        {
            return AuthorRepository.AuthorExist(id);
        }

        public async Task DeleteAuthor(Author author)
        {
            await AuthorRepository.DeleteAuthor(author);
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return AuthorRepository.Authors;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await AuthorRepository.GetAuthorById(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await AuthorRepository.SaveChangesAsync();
        }

        public async Task UpdateAddress(Address address)
        {
            await AuthorRepository.UpdateAddress(address);
        }
    }
}
