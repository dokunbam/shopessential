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
    [Authorize]
    public class SalesController : Controller
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            ViewData["ProductsName"] = _context.Products.Where(p => p.ProductName == p.ProductName);
            return View(await _context.Sales.ToListAsync());
           
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetCategory([FromBody] ProductPrice category)
        {
           

            var result = _context.Products.Where(p => p.CategoryId == category.CategoryID).ToList();
            return Json(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetPrice([FromBody] ProductPrice price)
        {
            var result = _context.Products.Where(p => p.ProductName.Contains(price.Productprice)).SingleOrDefault();
       
            return Json(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody]List<Sale> sales)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager .GetUserAsync(HttpContext.User);
                var store = _context.Stores.FirstOrDefault(m => m.ApplicationUserId == currentUser.Id);

                foreach (Sale sale in sales)
                {
                    sale.StoreId = store.Id;
                    sale.ApplicationUserId = currentUser.Id;
                    _context.Sales.Add(sale);
                }
       
            }
            var status = _context.SaveChanges();
            return Json(status);
        }

        //public void UpdateQuantity([FromBody] Sale Quantity)
        //{
        //    var result = _context.Products.Where(p => p.Quantity == Quantity.QuantityPurchased);
        //    foreach (var item in result)
        //    {
        //       // _context.Products.Select(p => p.Quantity - item);
        //    }
        //}


        // GET: Sales/Create
        /// <summary>
        /// / public async Task<IActionResult> AddProduct([FromBody]List<Sale> sales)
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            string userId = currentUser.Id.ToString();
            ViewData["CustomerId"] = new SelectList(_context.Customers.Where(c => c.ApplicationUserId == userId), "ID", "Name");

            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(p => p.ApplicationUserId == userId), "CategoryId", "CategoryName");

            ViewData["ProductId"] = new SelectList(_context.Products.Where(p => p.ApplicationUserId == userId), "ProductId", "ProductName");

            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            //ViewData["CategoryId"] = new SelectList(_context.Categories.Where(p =>p.StoreId == currentUser.Id) , "CategoryId", "CategoryName");

            return View();
        }

     

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,CustomerId,productId,StaffName,QuantityPurchased,Price,TotalAmountDue,TotalAmountPaid,Balance")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,CustomerId,productId,StaffId,QuantityPurchased,Price,TotalAmountDue,TotalAmountPaid,Balance")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleId))
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
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SaleId == id);
        }
    }
}
