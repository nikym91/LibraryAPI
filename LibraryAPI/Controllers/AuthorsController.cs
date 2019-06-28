using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.EF_DBLayer;
using LibraryAPI.Models;
using LibraryAPI.Models.Interfaces;
using LibraryAPI.Controllers.DTO;
using AutoMapper;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorUnitOfWork AuthorUnitOfWork;
        private readonly IMapper Mapper;

        public AuthorsController(AuthorUnitOfWork unit, IMapper mapper)
        {
            AuthorUnitOfWork = unit;
            Mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<AuthorDTO[]>> GetAuthors()
        {
            var authors = await AuthorUnitOfWork.GetAllAuthors().ToArrayAsync();
            return Mapper.Map<AuthorDTO[]>(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await AuthorUnitOfWork.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        public async Task UpdateAddress(Address address)
        {
            await AuthorUnitOfWork.UpdateAddress(address);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDTO>> PutAuthor([FromRoute] int id, [FromBody] AuthorDTO author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            await UpdateAddress(author.Address);
            var oldAuthor = await AuthorUnitOfWork.GetAuthorById(id);
            Mapper.Map(author, oldAuthor);

            try
            {
                    if (await AuthorUnitOfWork.SaveChangesAsync())
                    {
                        return Mapper.Map<AuthorDTO>(oldAuthor);
                    }
                }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor([FromBody] AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = Mapper.Map<Author>(authorDTO);
            await AuthorUnitOfWork.AddAuthorAsync(author);

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await AuthorUnitOfWork.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            await AuthorUnitOfWork.DeleteAuthor(author);
            return Ok(author);
        }

        private bool AuthorExists(int id)
        {
            return AuthorUnitOfWork.AuthorExist(id);
        }
    }
}