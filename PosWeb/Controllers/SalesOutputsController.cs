using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PosWeb.Data;
using PosWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Controllers
{
    [Authorize]
    public class SalesOutputsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOutputsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesOutputs
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetSalesOutputs.ToListAsync());
        }

        // GET: SalesOutputs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOutput = await _context.GetSalesOutputs
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            ViewData["SalesDetails"] = _context.Sales.Where(p => p.TransactionId == id).ToList();

            if (salesOutput == null)
            {
                return NotFound();
            }

            return View(salesOutput);
        }

        // GET: SalesOutputs/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddProductCalculations ([FromBody]List<SalesOutput> outputs)
        {
            if (ModelState.IsValid)
            {

                foreach (SalesOutput output in outputs)
                {
                    _context.GetSalesOutputs.Add(output);
                }
            }
            var status = _context.SaveChanges();
            return Json(status);
        }

        // POST: SalesOutputs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesOutputId,TransactionId,TotalAmountDue,TotalAmountPaid,Balance,SalesDate")] SalesOutput salesOutput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOutput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesOutput);
        }

        // GET: SalesOutputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOutput = await _context.GetSalesOutputs.FindAsync(id);
            if (salesOutput == null)
            {
                return NotFound();
            }
            return View(salesOutput);
        }

        // POST: SalesOutputs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesOutputId,TransactionId,TotalAmountDue,TotalAmountPaid,Balance,SalesDate")] SalesOutput salesOutput)
        {
            if (id != salesOutput.SalesOutputId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOutput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOutputExists(salesOutput.SalesOutputId))
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
            return View(salesOutput);
        }

        // GET: SalesOutputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOutput = await _context.GetSalesOutputs
                .FirstOrDefaultAsync(m => m.SalesOutputId == id);
            if (salesOutput == null)
            {
                return NotFound();
            }

            return View(salesOutput);
        }

        // POST: SalesOutputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOutput = await _context.GetSalesOutputs.FindAsync(id);
            _context.GetSalesOutputs.Remove(salesOutput);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOutputExists(int id)
        {
            return _context.GetSalesOutputs.Any(e => e.SalesOutputId == id);
        }
    }
}
