using MediatR.API.DTOs;

namespace MediatR.API.Queries.Books;

public class GetBookByIdRequest:IRequest<BookDTO>
{
    public int Id { get; set; }
}