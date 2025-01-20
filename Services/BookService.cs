using System.Collections.Generic;
using System.Threading.Tasks;
using SOLIDPRINCIPALS.ASPNETCORE.Interfaces;
using SOLIDPRINCIPALS.ASPNETCORE.Models;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ApiResponse<IEnumerable<Book>>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return ApiResponse<IEnumerable<Book>>.SuccessResponse(books);
    }

    public async Task<ApiResponse<Book>> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
        {
            return ApiResponse<Book>.ErrorResponse($"Book with ID {id} not found");
        }
        return ApiResponse<Book>.SuccessResponse(book);
    }

    public async Task<ApiResponse<Book>> AddBookAsync(Book book)
    {
        if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
        {
            return ApiResponse<Book>.ErrorResponse("Title and Author are required");
        }

        await _bookRepository.AddAsync(book);
        return ApiResponse<Book>.SuccessResponse(book, "Book added successfully");
    }

    public async Task<ApiResponse<Book>> UpdateBookAsync(Book book)
    {
        var existingBook = await _bookRepository.GetByIdAsync(book.Id);
        if (existingBook == null)
        {
            return ApiResponse<Book>.ErrorResponse($"Book with ID {book.Id} not found");
        }

        await _bookRepository.UpdateAsync(book);
        return ApiResponse<Book>.SuccessResponse(book, "Book updated successfully");
    }

    public async Task<ApiResponse<bool>> DeleteBookAsync(int id)
    {
        var existingBook = await _bookRepository.GetByIdAsync(id);
        if (existingBook == null)
        {
            return ApiResponse<bool>.ErrorResponse($"Book with ID {id} not found");
        }

        await _bookRepository.DeleteAsync(id);
        return ApiResponse<bool>.SuccessResponse(true, "Book deleted successfully");
    }

    public async Task<ApiResponse<IEnumerable<Book>>> SearchBooksByAuthorAsync(string author)
    {
        if (string.IsNullOrEmpty(author))
        {
            return ApiResponse<IEnumerable<Book>>.ErrorResponse("Author search term cannot be empty");
        }

        var books = await _bookRepository.SearchByAuthorAsync(author);
        return ApiResponse<IEnumerable<Book>>.SuccessResponse(books);
    }
} 