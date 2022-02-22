using MediatR.API.DTOs;
using MediatR.API.Entities;

namespace MediatR.API.Repositories.Books;

public interface IBooksRepository
{
    Task<IList<Book>> GetAll();
    Task<Book> GetById(int id);
    Task<bool> Update(BookDTO bookDTO, int id);
    Task<bool> Delete(int id);
    Task<bool> Insert(BookDTO bookDTO);
}