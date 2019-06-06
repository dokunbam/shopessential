using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PosWeb.Data;
using PosWeb.Models;

namespace PosWeb.Controllers
{
    [Authorize]
    public class SalesDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesDetails.ToListAsync());
        }

        // GET: SalesDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetails = await _context.SalesDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salesDetails == null)
            {
                return NotFound();
            }

            return View(salesDetails);
        }

        // GET: SalesDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SalesId")] SalesDetails salesDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesDetails);
        }

        // GET: SalesDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetails = await _context.SalesDetails.FindAsync(id);
            if (salesDetails == null)
            {
                return NotFound();
            }
            return View(salesDetails);
        }

        // POST: SalesDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SalesId")] SalesDetails salesDetails)
        {
            if (id != salesDetails.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesDetailsExists(salesDetails.ID))
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
            return View(salesDetails);
        }

        // GET: SalesDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetails = await _context.SalesDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salesDetails == null)
            {
                return NotFound();
            }

            return View(salesDetails);
        }

        // POST: SalesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesDetails = await _context.SalesDetails.FindAsync(id);
            _context.SalesDetails.Remove(salesDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesDetailsExists(int id)
        {
            return _context.SalesDetails.Any(e => e.ID == id);
        }
    }
}
