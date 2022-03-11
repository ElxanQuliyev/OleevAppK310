#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OleevAppK310.Models;

namespace OleevAppK310.Areas.AdminOlev.Controllers
{
    [Area("AdminOlev")]
    public class ReservCategoriesController : Controller
    {
        private readonly OlDbContext _context;

        public ReservCategoriesController(OlDbContext context)
        {
            _context = context;
        }

        // GET: AdminOlev/ReservCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservCategories.ToListAsync());
        }

        // GET: AdminOlev/ReservCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservCategory = await _context.ReservCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservCategory == null)
            {
                return NotFound();
            }

            return View(reservCategory);
        }

        // GET: AdminOlev/ReservCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminOlev/ReservCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ReservCategory reservCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservCategory);
        }

        // GET: AdminOlev/ReservCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservCategory = await _context.ReservCategories.FindAsync(id);
            if (reservCategory == null)
            {
                return NotFound();
            }
            return View(reservCategory);
        }

        // POST: AdminOlev/ReservCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ReservCategory reservCategory)
        {
            if (id != reservCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservCategoryExists(reservCategory.Id))
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
            return View(reservCategory);
        }

        // GET: AdminOlev/ReservCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservCategory = await _context.ReservCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservCategory == null)
            {
                return NotFound();
            }

            return View(reservCategory);
        }

        // POST: AdminOlev/ReservCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservCategory = await _context.ReservCategories.FindAsync(id);
            _context.ReservCategories.Remove(reservCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservCategoryExists(int id)
        {
            return _context.ReservCategories.Any(e => e.Id == id);
        }
    }
}
