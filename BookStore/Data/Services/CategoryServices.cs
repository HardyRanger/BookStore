using BookStore.Models;
using BookStore.Data.Base;

namespace BookStore.Data.Services
{
    public class CategoryServices : EntityBaseRepository<Category>, ICategoryServices
    {
        public CategoryServices(BookContext context) : base(context)
        {

        }
    }
}
