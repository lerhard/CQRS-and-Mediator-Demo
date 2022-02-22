namespace MediatR.API.Commands;

public class InsertBookCommandRequest: IRequest<bool>
{
    public string Name { get; set; }
    public string Category { get; set; }
}