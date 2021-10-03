using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Apione.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository BookRepository)
        {
          _bookRepository = BookRepository;
        }

        // Get All data
       [HttpGet]
       public async Task<IActionResult> GetAllBooks()
       {
           var books = await _bookRepository.GetAllBooksAsync();
           return Ok(books);
       }

        // Get data by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBooksByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // Add new record
        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookmodel)
        {
            var id = await _bookRepository.AddBookAsync(bookmodel);

            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "books" }, id);
        }

        //Update record by Id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookmodel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookmodel);

            return Ok();
        }

        //Patch(update) data by Id
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookmodel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookPatchAsync(id, bookmodel);

            return Ok();
        }

        // Delete record by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);

            return Ok();
        }
    }
}
