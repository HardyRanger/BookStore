using BookStore.Data.Base;
using BookStore.Models;

namespace BookStore.Data.Services
{
    public class AuthorServices: EntityBaseRepository<Author>, IAuthorServices
    {
        public AuthorServices( BookContext context): base(context) 
        {
            
        }
    }
}
