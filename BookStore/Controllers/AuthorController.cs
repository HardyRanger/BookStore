using BookStore.Data;
using BookStore.Data.Services;
using BookStore.Data.Staic;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class AuthorController : Controller
    {
       

        private readonly IAuthorServices _services;

        public AuthorController(IAuthorServices services)
        {
            _services = services;
        }
    
    public async Task<IActionResult> Index()
        {
            var allAuthors =await _services.GetAllAsync();
            return View(allAuthors);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var authorDetails = await _services.GetByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Author author)
        {
            if (!ModelState.IsValid) return View(author);

            await _services.AddAsync(author);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var authorDetails = await _services.GetByIdAsync(id);
            if (authorDetails == null) return View("Not Found");
            return View(authorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,FullName,Bio")] Author author)
        {

            if (!ModelState.IsValid) return View(author);
            if(id == author.Id)
            {
                await _services.UpdateAsync(id, author);
                return RedirectToAction(nameof(Index));
            }
           
            return View(author);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var authorDetails = await _services.GetByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorDetails = await _services.GetByIdAsync(id);
            if (authorDetails == null) return View("NotFound");

            try
            {
                await _services.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    ViewBag.ErrorMessage = "This author cannot be deleted as there are associated books.";
                    return View("Delete", authorDetails);
                }
                throw;
            }
        }



    }
}
