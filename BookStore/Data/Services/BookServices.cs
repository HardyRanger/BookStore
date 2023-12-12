using BookStore.Data.Base;
using BookStore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStore.Data.ViewModels;

namespace BookStore.Data.Services
{
    
    public class BookServices : EntityBaseRepository<Books>, IBookService
    {
        private BookContext _context;
        public BookServices(BookContext context) : base(context)
        {
            _context = context;
        }

        public  async Task AddNewBookAsync(NewBookVM data)
        {

            var newBook = new Books()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CatId = data.CatId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                AuthorId = data.AuthorId
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(c => c.Author)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails;
        }

        public async Task<DropDownVM> GetDropDownValues()
        {
            var response = new DropDownVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync(),
                Authors = await _context.Authors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbBook != null)
            {
               dbBook.Name = data.Name;
               dbBook.Description = data.Description;
               dbBook.Price = data.Price;
               dbBook.ImageURL = data.ImageURL;
               dbBook.CatId = data.CatId;
               dbBook.StartDate = data.StartDate;
               dbBook.EndDate = data.EndDate;
               dbBook.AuthorId = data.AuthorId;
                await _context.SaveChangesAsync();
            }

        }
    }
}
