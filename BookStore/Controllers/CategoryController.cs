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
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var allCategories = await _services.GetAllAsync();
            return View(allCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _services.GetByIdAsync(id);
            if (category == null)
            {
                return View("NotFound");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _services.UpdateAsync(id, category);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return View(category);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var category = await _services.GetByIdAsync(id);
            if (category == null)
            {
                return View("NotFound");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetails = await _services.GetByIdAsync(id);
            if (categoryDetails == null)
            {
                return View("NotFound");
            }

            try
            {
                await _services.DeleteAsync(id);
                return RedirectToAction("Index"); 
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    ViewBag.ErrorMessage = "This category cannot be deleted as there are associated Books.";
                    return View("Delete", categoryDetails);
                }
                throw;
            }
        }


    }
}
