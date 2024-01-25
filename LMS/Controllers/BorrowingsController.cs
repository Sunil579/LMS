using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.Data;
using LMS.Models;

namespace LMS.Controllers
{
    public class BorrowingsController : Controller
    {
        private readonly LibraryManagementSystemContext _context;

        public BorrowingsController(LibraryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Borrowings
        public async Task<IActionResult> Index()
        {
              return _context.Borrowings != null ? 
                          View(await _context.Borrowings.ToListAsync()) :
                          Problem("Entity set 'LibraryManagementSystemContext.Borrowings'  is null.");
        }

        // GET: Borrowings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Borrowings == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings
                .FirstOrDefaultAsync(m => m.BorrowingID == id);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        // GET: Borrowings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Borrowings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowingID,MyProperty,BookID,StudentID,DateBorrowed,DateRetuened")] Borrowing borrowing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(borrowing);
        }

        // GET: Borrowings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Borrowings == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings.FindAsync(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            return View(borrowing);
        }

        // POST: Borrowings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowingID,MyProperty,BookID,StudentID,DateBorrowed,DateRetuened")] Borrowing borrowing)
        {
            if (id != borrowing.BorrowingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowingExists(borrowing.BorrowingID))
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
            return View(borrowing);
        }

        // GET: Borrowings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Borrowings == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings
                .FirstOrDefaultAsync(m => m.BorrowingID == id);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        // POST: Borrowings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Borrowings == null)
            {
                return Problem("Entity set 'LibraryManagementSystemContext.Borrowings'  is null.");
            }
            var borrowing = await _context.Borrowings.FindAsync(id);
            if (borrowing != null)
            {
                _context.Borrowings.Remove(borrowing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowingExists(int id)
        {
          return (_context.Borrowings?.Any(e => e.BorrowingID == id)).GetValueOrDefault();
        }
    }
}
