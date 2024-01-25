﻿using System;
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
    public class LibrariansController : Controller
    {
        private readonly LibraryManagementSystemContext _context;

        public LibrariansController(LibraryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Librarians
        public async Task<IActionResult> Index()
        {
              return _context.Librarians != null ? 
                          View(await _context.Librarians.ToListAsync()) :
                          Problem("Entity set 'LibraryManagementSystemContext.Librarians'  is null.");
        }

        // GET: Librarians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Librarians == null)
            {
                return NotFound();
            }

            var librarian = await _context.Librarians
                .FirstOrDefaultAsync(m => m.LibrarianID == id);
            if (librarian == null)
            {
                return NotFound();
            }

            return View(librarian);
        }

        // GET: Librarians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Librarians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibrarianID,LibrarianName,LibrarianEmail,LibrarianPhoneNum,LibrarianRole,LUsername,LPassword")] Librarian librarian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librarian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(librarian);
        }

        // GET: Librarians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Librarians == null)
            {
                return NotFound();
            }

            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian == null)
            {
                return NotFound();
            }
            return View(librarian);
        }

        // POST: Librarians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibrarianID,LibrarianName,LibrarianEmail,LibrarianPhoneNum,LibrarianRole,LUsername,LPassword")] Librarian librarian)
        {
            if (id != librarian.LibrarianID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(librarian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrarianExists(librarian.LibrarianID))
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
            return View(librarian);
        }

        // GET: Librarians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Librarians == null)
            {
                return NotFound();
            }

            var librarian = await _context.Librarians
                .FirstOrDefaultAsync(m => m.LibrarianID == id);
            if (librarian == null)
            {
                return NotFound();
            }

            return View(librarian);
        }

        // POST: Librarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Librarians == null)
            {
                return Problem("Entity set 'LibraryManagementSystemContext.Librarians'  is null.");
            }
            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian != null)
            {
                _context.Librarians.Remove(librarian);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrarianExists(int id)
        {
          return (_context.Librarians?.Any(e => e.LibrarianID == id)).GetValueOrDefault();
        }
    }
}
