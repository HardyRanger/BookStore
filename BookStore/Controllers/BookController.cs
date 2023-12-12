using BookStore.Data;
using BookStore.Data.Services;
using BookStore.Data.Staic;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Authorize]

    public class BookController : Controller
    {
        private readonly IBookService _services;

        public BookController(IBookService service)
        {
            _services = service;
        }


        public async Task<IActionResult> Index(string searchString)
        {
            var allBooks = await _services.GetAllAsync(n => n.Author, n => n.Category);

            if (!string.IsNullOrEmpty(searchString))
            {
               
                allBooks = allBooks.Where(book => book.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(allBooks);
        }


        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _services.GetBookByIdAsync(id);
            return View(bookDetail);
        }
       

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create()
        {
           
                var bookDropdownsData = await _services.GetDropDownValues();

                ViewBag.Category = new SelectList(bookDropdownsData.Categories, "Id", "Name");
               ViewBag.Author = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View();
         
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _services.GetDropDownValues();

                ViewBag.Category = new SelectList(movieDropdownsData.Categories, "Id", "Name");
                ViewBag.Author = new SelectList(movieDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            await _services.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _services.GetBookByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                CatId = movieDetails.CatId,
                AuthorId = movieDetails.AuthorId,
            };

            var movieDropdownsData = await _services.GetDropDownValues();

            ViewBag.Category = new SelectList(movieDropdownsData.Categories, "Id", "Name");
            ViewBag.Author = new SelectList(movieDropdownsData.Authors, "Id", "FullName");

            return View(response);
        }
        [Authorize(Roles = UserRoles.Admin)]

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _services.GetDropDownValues();

                ViewBag.Category = new SelectList(movieDropdownsData.Categories, "Id", "Name");
                ViewBag.Author = new SelectList(movieDropdownsData.Authors, "Id", "FullName");
                return View(book);
            }

            await _services.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

    }
}

