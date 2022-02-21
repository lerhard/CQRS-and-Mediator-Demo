using MediatR.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.API.Controllers;

[Route("/books")]
public class BooksController : Controller
{
    [HttpGet("v1/get-all")]
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }

    [HttpGet("v1/get/{id:int}")]
    public IActionResult Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("v1/insert")]
    public IActionResult Insert(Book book)
    {
        throw new NotImplementedException();
    }

    [HttpPut("v1/update")]
    public IActionResult Update(Book book)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("v1/delete")]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}