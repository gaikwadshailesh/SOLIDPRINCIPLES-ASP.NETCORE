public interface IBookRepository : IReadRepository<Book>, IWriteRepository<Book>
{
    Task<IEnumerable<Book>> SearchByAuthorAsync(string author);
} 