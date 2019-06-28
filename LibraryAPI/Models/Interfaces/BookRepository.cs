using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Interfaces
{
    public interface BookRepository
    {
        IQueryable<Book> Books { get; }

        Task<Book> GetBookById(int id);
        Task AddBookAsync(Book book);
        Task DeleteBook(Book book);
        bool BookExist(int id);
        Task<bool> SaveChangesAsync();
    }
}
