using MediatR.API.DTOs;
using MediatR.API.Entities;
using MediatR.API.Queries.Books;
using MediatR.API.Repositories.Books;

namespace MediatR.API.Handlers.Queries;

public class GetAllBooksRequestHandler: IRequestHandler<GetAllBooksRequest,IList<BookDTO>>
{
    private readonly IBooksRepository _repository;

    public GetAllBooksRequestHandler(IBooksRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<BookDTO>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
    {
        IList<Book> books = await _repository.GetAll();

        return books.Select(t => new BookDTO() {Category = t.Category, Name = t.Name}).ToList();
    }
}