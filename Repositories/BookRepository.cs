using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOLIDPRINCIPALS.ASPNETCORE.Interfaces;
using SOLIDPRINCIPALS.ASPNETCORE.Models;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books;

    public BookRepository()
    {
        _books = new List<Book>();
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await Task.FromResult(_books);
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await Task.FromResult(_books.FirstOrDefault(b => b.Id == id));
    }

    public async Task AddAsync(Book entity)
    {
        _books.Add(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Book entity)
    {
        var book = _books.FirstOrDefault(b => b.Id == entity.Id);
        if (book != null)
        {
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.ISBN = entity.ISBN;
            book.Price = entity.Price;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            _books.Remove(book);
        }
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Book>> SearchByAuthorAsync(string author)
    {
        return await Task.FromResult(_books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)));
    }
} 