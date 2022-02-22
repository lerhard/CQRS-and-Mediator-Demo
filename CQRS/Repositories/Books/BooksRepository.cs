using MediatR.API.DTOs;
using MediatR.API.Entities;

namespace MediatR.API.Repositories.Books;

public class BooksRepository : IBooksRepository
{
    private static IList<Book> _books;

    public BooksRepository()
    {
        CreateBooksIfNotExists();
    }

    public async Task<IList<Book>> GetAll()
    {
        await Task.Run(() => CreateBooksIfNotExists());
        return _books;
    }

    public async Task<Book> GetById(int id)
    {
        CreateBooksIfNotExists();
        return await Task.Run(() => _books.FirstOrDefault(x => x.Id == id));
    }

    public async Task<bool> Update(BookDTO bookDTO, int id)
    {

        
        if (bookDTO is null) throw new ArgumentNullException("book");
        if (id is default(int)) throw new ArgumentException("id cannot  be 0");
        
        Book book = new(id, bookDTO.Name, bookDTO.Category);
        CreateBooksIfNotExists();
        Book oldBook = await Task.Run(() => _books.FirstOrDefault(x => x.Id == book.Id));
        if (oldBook is null) throw new NullReferenceException("Book cannot be updated: it doesn't exists");
        int index = await Task.Run(() => _books.IndexOf(oldBook));

        oldBook.ChangeName(book.Name);
        oldBook.ChangeCategory(book.Category);
        _books[index] = oldBook;

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        if (id is 0) throw new ArgumentException("id cannot be '0'");
        CreateBooksIfNotExists();

        Book book =  await Task.Run (() =>_books.FirstOrDefault(x => x.Id == id));
        if (book is null) throw new NullReferenceException("This book doesn't exists");

        return _books.Remove(book);
    }

    public async Task<bool> Insert(BookDTO bookDTO)
    {
        if (bookDTO is null) throw new ArgumentNullException("book");

        Book book = new Book(bookDTO.Name, bookDTO.Category);
        CreateBooksIfNotExists();

        if (book.Id is default(int))
            book.ChangeId(_books.Count + 1);

        await Task.Run(() => _books.Add(book));
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