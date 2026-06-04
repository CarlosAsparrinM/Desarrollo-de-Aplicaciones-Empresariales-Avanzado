using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVDemo2026.Models;

namespace MVDemo2026.Controllers
{
    public class DetailsController : Controller
    {
        private readonly DemoContext _context;

        public DetailsController(DemoContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
            var demoContext = _context.Details.Include(d => d.Invoice).Include(d => d.Product);
            return View(await demoContext.ToListAsync());
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details
                .Include(d => d.Invoice)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DetailID == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            ViewData["Invoice_InvoiceID"] = new SelectList(_context.Invoices, "InvoiceID", "InvoiceID");
            ViewData["Product_ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailID,Product_ProductID,Invoice_InvoiceID,Amount,Price,SubTotal")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Invoice_InvoiceID"] = new SelectList(_context.Invoices, "InvoiceID", "InvoiceID", detail.Invoice_InvoiceID);
            ViewData["Product_ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", detail.Product_ProductID);
            return View(detail);
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            ViewData["Invoice_InvoiceID"] = new SelectList(_context.Invoices, "InvoiceID", "InvoiceID", detail.Invoice_InvoiceID);
            ViewData["Product_ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", detail.Product_ProductID);
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailID,Product_ProductID,Invoice_InvoiceID,Amount,Price,SubTotal")] Detail detail)
        {
            if (id != detail.DetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.DetailID))
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
            ViewData["Invoice_InvoiceID"] = new SelectList(_context.Invoices, "InvoiceID", "InvoiceID", detail.Invoice_InvoiceID);
            ViewData["Product_ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", detail.Product_ProductID);
            return View(detail);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details
                .Include(d => d.Invoice)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DetailID == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Details.FindAsync(id);
            if (detail != null)
            {
                detail.IsDeleted = true;
                _context.Update(detail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExists(int id)
        {
            return _context.Details.Any(e => e.DetailID == id);
        }
    }
}
