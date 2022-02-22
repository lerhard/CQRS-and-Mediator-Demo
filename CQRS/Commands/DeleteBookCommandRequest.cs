namespace MediatR.API.Commands;

public class DeleteBookCommandRequest : IRequest<bool>
{
   public int Id { get; set; } 
}