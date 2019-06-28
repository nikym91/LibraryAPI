using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.EF_DBLayer;
using LibraryAPI.Models;
using AutoMapper;
using LibraryAPI.Controllers.DTO;
using LibraryAPI.Models.Interfaces;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookUnitOfWork bookUnitOfWork;
        private readonly IMapper Mapper;

        public BooksController(BookUnitOfWork b, IMapper mapper)
        {
            bookUnitOfWork = b;
            Mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<BookDTO[]>> GetBooks()
        {
            var books = await bookUnitOfWork.GetAllBooks().ToArrayAsync();
            return Mapper.Map<BookDTO[]>(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO[]>> GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await bookUnitOfWork.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Mapper.Map<BookDTO[]>(book);
        }

        // PUT: api/Books/5
        [HttpPut("{bookId}")]
        public async Task<ActionResult<BookDTO>> Put([FromRoute] int bookId, [FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (bookId != book.BookId)
            {
                return BadRequest();
            }

            var oldBook = await bookUnitOfWork.GetBookById(bookId);
            Mapper.Map(book, oldBook);
            try
            {
                if (await bookUnitOfWork.SaveChangesAsync())
                {
                    return Mapper.Map<BookDTO>(oldBook);
                }
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(bookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return BadRequest();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDTO>> Post([FromBody] BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = Mapper.Map<Book>(bookDTO);
            await bookUnitOfWork.AddBookAsync(book);
           
            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await bookUnitOfWork.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            await bookUnitOfWork.DeleteBook(book);

            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return bookUnitOfWork.BookExist(id);
        }
    }
}