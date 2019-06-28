using LibraryAPI.Models;
using LibraryAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.EF_DBLayer
{
    public class EFBookRepository : BookRepository
    {
        private readonly ApplicationDbContext context;
        public EFBookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Book> Books => context.Books.Include(a => a.Author);

        public async Task AddBookAsync(Book book)
        {
            context.Books.Add(book);
            await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }

        public async Task<Book> GetBookById(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task DeleteBook(Book book)
        {
            context.Books.Remove(book);
            await SaveChangesAsync();
        }

        public bool BookExist(int id)
        {
            return context.Books.Any(e => e.BookId == id);
        }
    }
}
