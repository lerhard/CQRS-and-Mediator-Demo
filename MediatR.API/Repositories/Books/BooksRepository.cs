using MediatR.API.Entities;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace MediatR.API.Repositories.Books;

public class BooksRepository : IBooksRepository
{
    private static IList<Book> _books;

    public BooksRepository()
    {
        CreateBooksIfNotExists();
    }

    public IList<Book> GetAll()
    {
        CreateBooksIfNotExists();
        return _books;
    }

    public Book GetById(int id)
    {
        CreateBooksIfNotExists();
        return _books.FirstOrDefault(x => x.Id == id);
    }

    public bool Update(Book book)
    {
        if (book is null) throw new ArgumentNullException("book");
        CreateBooksIfNotExists();
        
        Book oldBook =  _books.FirstOrDefault(x => x.Id == book.Id);
        if (oldBook is null) throw new NullReferenceException("Book cannot be updated: it doesn't exists");
        int index = _books.IndexOf(oldBook);
        
        oldBook.ChangeName(book.Name);
        oldBook.ChangeCategory(book.Category);
        _books[index] = oldBook;

        return true;
    }

    public bool Delete(int id)
    {
        if (id is 0) throw new ArgumentException("id cannot be '0'");
        CreateBooksIfNotExists();

        Book book = _books.FirstOrDefault(x => x.Id == id);
        if (book is null) throw new NullReferenceException("This book doesn't exists");

        return _books.Remove(book);
    }

    public bool Insert(Book book)
    {
        if (book is null) throw new ArgumentNullException("book");
        CreateBooksIfNotExists();

        if (book.Id is default(int))
            book.ChangeId(_books.Count + 1);
        
        _books.Add(book);
        return true;

    }

    private void CreateBooksIfNotExists()
    {
        if (_books is not null && _books.Count != 0) return;

        _books = new List<Book>();
        _books.Add(new Book(1, "20 mil léguas submarinas", "science fiction"));
        _books.Add(new Book(2, "Memórias Póstumas de Brás Cubas", "Romance"));
        _books.Add(new Book(3, "Memórias de Um sargento de milícias", "Romance"));
    }
}