public interface IBookService
{
    Task<ApiResponse<IEnumerable<Book>>> GetAllBooksAsync();
    Task<ApiResponse<Book>> GetBookByIdAsync(int id);
    Task<ApiResponse<Book>> AddBookAsync(Book book);
    Task<ApiResponse<Book>> UpdateBookAsync(Book book);
    Task<ApiResponse<bool>> DeleteBookAsync(int id);
    Task<ApiResponse<IEnumerable<Book>>> SearchBooksByAuthorAsync(string author);
} 