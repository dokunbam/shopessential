using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PosWeb.Data;
using PosWeb.Models;

namespace PosWeb.Controllers
{
  
    public class CategoriesController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var category = _context.Categories.Where(m=>m.ApplicationUserId == currentUser.Id);

            return View(await category.ToListAsync());
        }

        // GET: Categories/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var category = await _context.Categories.FindAsync(id);

            if (category.ApplicationUserId != currentUser.Id)
            {
                return RedirectToAction(nameof(Index));

                //return View(category);
            }

            var categor = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categor == null)
            {
                return NotFound();
            }

            return View(categor);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,StoreId,ApplicationUserId,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var store = _context.Stores.FirstOrDefault(m => m.ApplicationUserId == currentUser.Id);
                //var applicationId = _context.Stores.FirstOrDefaultAsync(m=>m.ApplicationUserId == )

                category.StoreId = store.Id;
                category.ApplicationUserId = currentUser.Id;
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var category = await _context.Categories.FindAsync(id);

            if (category.ApplicationUserId != currentUser.Id)
            {
                return RedirectToAction(nameof(Index));

                //return View(category);
            }
            else
            {
                var categor = await _context.Categories.FindAsync(id);

                if (categor == null)
                {
                    return NotFound();
                }

                return View(categor);
                
            }
            
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,StoreId,ApplicationUserId,CategoryName,Description")] Category category)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var store = _context.Stores.FirstOrDefault(m => m.ApplicationUserId == currentUser.Id);
            //var categories = _context.Categories.FirstOrDefault(m => m.ApplicationUserId == currentUser.Id);

            if (id != category.CategoryId)
            {
                return NotFound();
            }

          
            //var categories = await _context.Categories.FindAsync(id);

            //if (categories.ApplicationUserId != currentUser.Id)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
           
                if (ModelState.IsValid)
                {

                    try
                    {

                        category.StoreId = store.Id;
                        category.ApplicationUserId = currentUser.Id;
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.CategoryId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
            
            return View(category);
        }

        // GET: Categories/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var category = await _context.Categories.FindAsync(id);

            if (category.ApplicationUserId != currentUser.Id)
            {
                return RedirectToAction(nameof(Index));

                //return View(category);
            }


            var categor = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categor == null)
            {
                return NotFound();
            }

            return View(categor);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
