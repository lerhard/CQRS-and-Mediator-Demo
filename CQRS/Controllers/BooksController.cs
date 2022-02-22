using MediatR.API.Commands;
using MediatR.API.DTOs;
using MediatR.API.Queries.Books;
using MediatR.API.Repositories.Books;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.API.Controllers;

[Route("/books")]
public class BooksController : Controller
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("v1/get-all")]
    public async Task<IActionResult> GetAll(GetAllBooksRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet("v1/get")]
    public async Task<IActionResult> Get(GetBookByIdRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost("v1/insert")]
    public async Task<IActionResult> Insert(InsertBookCommandRequest request)
    {
        return Ok(request != null && await _mediator.Send(request));
    }

    [HttpPut("v1/update")]
    public async Task<IActionResult> Update(UpdateBookCommandRequest request)
    {
        return Ok(request != null && _mediator != null && await _mediator.Send(request));
    }

    [HttpDelete("v1/delete")]
    public async Task<IActionResult> Delete(DeleteBookCommandRequest request)
    {
        return Ok(request != null && await _mediator.Send(request));
    }
}