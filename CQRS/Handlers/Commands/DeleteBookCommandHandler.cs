using MediatR.API.Commands;
using MediatR.API.Repositories.Books;

namespace MediatR.API.Handlers.Commands;

public class DeleteBookCommandHandler: IRequestHandler<DeleteBookCommandRequest,bool>
{
    private IBooksRepository _repository;
    
    public DeleteBookCommandHandler(IBooksRepository repository)
    {
        _repository = repository;
    }


    public async Task<bool> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.Id);
    }
}