using MediatR.API.Commands;
using MediatR.API.DTOs;
using MediatR.API.Repositories.Books;

namespace MediatR.API.Handlers.Commands;

public class InsertBookCommandHandler: IRequestHandler<InsertBookCommandRequest,bool>
{
    private readonly IBooksRepository _repository;

    public InsertBookCommandHandler(IBooksRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(InsertBookCommandRequest request, CancellationToken cancellationToken)
    {
        var bookDto = new BookDTO
        {
            Category = request.Category,
            Name = request.Name
        };

        var result = await _repository.Insert(bookDto);

        return result;
    }
}