using MediatR.API.DTOs;
using MediatR.API.Entities;
using MediatR.API.Queries.Books;
using MediatR.API.Repositories.Books;

namespace MediatR.API.Handlers.Queries;

public class GetBookByIdRequestHandler: IRequestHandler<GetBookByIdRequest, BookDTO>
{
    private readonly IBooksRepository _repository;

    public GetBookByIdRequestHandler(IBooksRepository repository)
    {
        _repository = repository;
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