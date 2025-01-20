using Microsoft.AspNetCore.Mvc;
using SOLIDPRINCIPALS.ASPNETCORE.Interfaces;
using SOLIDPRINCIPALS.ASPNETCORE.Models;

namespace SOLIDPRINCIPALS.ASPNETCORE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Book>>>> GetBooks()
        {
            var response = await _bookService.GetAllBooksAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Book>>> GetBook(int id)
        {
            var response = await _bookService.GetBookByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Book>>> CreateBook(Book book)
        {
            var response = await _bookService.AddBookAsync(book);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Book>>> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest(ApiResponse<Book>.ErrorResponse("ID mismatch"));
            }

            var response = await _bookService.UpdateBookAsync(book);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBookAsync(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Book>>>> SearchBooks([FromQuery] string author)
        {
            var response = await _bookService.SearchBooksByAuthorAsync(author);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
} 