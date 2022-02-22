using MediatR.API.Repositories.Books;

namespace MediatR.API.Repositories;

public static class DependencyInjection
{
   public static void AddRepositories(this IServiceCollection services)
   {
      services.AddTransient<IBooksRepository, BooksRepository>();
   } 
}