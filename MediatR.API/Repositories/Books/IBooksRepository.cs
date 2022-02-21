using MediatR.API.Entities;

namespace MediatR.API.Repositories.Books;

public interface IBooksRepository
{
   public IList<Book> GetAll();
   public Book GetById(int id);
   public bool Update(Book book);
   public bool Delete(int id);
   public bool Insert(Book book);
}