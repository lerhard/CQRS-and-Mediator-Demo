namespace MediatR.API.Commands;

public class UpdateBookCommandRequest:IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
}