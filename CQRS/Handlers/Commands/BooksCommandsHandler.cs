using MediatR.API.Commands;
using MediatR.API.DTOs;
using MediatR.API.Repositories.Books;

namespace MediatR.API.Handlers.Commands;

public class BooksCommandsHandler : IRequestHandler<DeleteBookCommandRequest, bool>,
    IRequestHandler<InsertBookCommandRequest, bool>, IRequestHandler<UpdateBookCommandRequest, bool>
{
    private readonly IBooksRepository _repository;

    public BooksCommandsHandler(IBooksRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.Id);
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