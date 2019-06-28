using LibraryAPI.Models;
using LibraryAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.EF_DBLayer
{
    public class EFBookUnitOfWork : BookUnitOfWork
    {
        private readonly BookRepository bookRepository;
        public EFBookUnitOfWork(BookRepository repo)
        {
            bookRepository = repo;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await bookRepository.SaveChangesAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            await bookRepository.AddBookAsync(book);
        }

        public bool BookExist(int id)
        {
            return bookRepository.BookExist(id);
        }

        public async Task DeleteBook(Book book)
        {
            await bookRepository.DeleteBook(book);
        }

        public IQueryable<Book> GetAllBooks()
        {
            return bookRepository.Books;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await bookRepository.GetBookById(id);
        }
    }
}
