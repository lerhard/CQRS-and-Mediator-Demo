using MediatR.API.DTOs;

namespace MediatR.API.Queries.Books;

public class GetAllBooksRequest: IRequest<IList<BookDTO>>
{
    
}