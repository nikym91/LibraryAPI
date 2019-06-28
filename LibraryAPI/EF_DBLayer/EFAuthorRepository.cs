using LibraryAPI.Models;
using LibraryAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.EF_DBLayer
{
    public class EFAuthorRepository : AuthorRepository
    {
        private readonly ApplicationDbContext context;
        public EFAuthorRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Author> Authors => context.Authors.Include(a => a.Address);

        public async Task<Author> GetAuthorById(int id)
        {
            return await context.Authors.FindAsync(id);
        }

        public async Task UpdateAddress(Address address)
        {
            context.Update(address);
            await SaveChangesAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (context.SaveChanges() > 0);
        }

        public async Task AddAuthorAsync(Author author)
        {
            context.Authors.Add(author);
            await SaveChangesAsync();
        }

        public async Task DeleteAuthor(Author author)
        {
            context.Authors.Remove(author);
            await SaveChangesAsync();
        }

        public bool AuthorExist(int id)
        {
            return context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
