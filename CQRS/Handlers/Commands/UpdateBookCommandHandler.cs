using MediatR.API.Commands;
using MediatR.API.DTOs;
using MediatR.API.Repositories.Books;

namespace MediatR.API.Handlers.Commands;

public class UpdateBookCommandHandler: IRequestHandler<UpdateBookCommandRequest,bool>
{
    private readonly IBooksRepository _repository;

    public UpdateBookCommandHandler(IBooksRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
    {
        var bookdto = new BookDTO
        {
            Name = request.Name,
            Category = request.Category
        };

        return await _repository.Update(bookdto, request.Id);
    }
}