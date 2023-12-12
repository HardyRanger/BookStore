using BookStore.Data.Base;
using BookStore.Data.ViewModels;
using BookStore.Models;

namespace BookStore.Data.Services
{
    public interface IBookService : IEntityBaseRepository<Books>
    {
        Task<Books> GetBookByIdAsync(int id);
        Task<DropDownVM> GetDropDownValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}
