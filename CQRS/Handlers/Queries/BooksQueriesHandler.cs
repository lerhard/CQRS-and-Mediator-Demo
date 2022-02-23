using MediatR.API.DTOs;
using MediatR.API.Entities;
using MediatR.API.Queries.Books;
using MediatR.API.Repositories.Books;

namespace MediatR.API.Handlers.Queries;

public class BooksQueriesHandler : IRequestHandler<GetAllBooksRequest, IList<BookDTO>>,
    IRequestHandler<GetBookByIdRequest, BookDTO>
{
    private readonly IBooksRepository _repository;

    public BooksQueriesHandler(IBooksRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<BookDTO>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
    {
        IList<Book> books = await _repository.GetAll();

        return books.Select(t => new BookDTO() {Category = t.Category, Name = t.Name}).ToList();
    }

    public async Task<BookDTO> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
    {
        Book book = await _repository.GetById(request.Id);
        var bookDTO = new BookDTO
        {
            Category = book.Category,
            Name = book.Name
        };

        return bookDTO;
    }
}