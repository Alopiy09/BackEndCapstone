using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backEndCapstone.Data;
using backEndCapstone.Models;

namespace backEndCapstone.Controllers
{
    public class SubClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubClass.ToListAsync());
        }

        // GET: SubClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subClass = await _context.SubClass
                .FirstOrDefaultAsync(m => m.SubClassId == id);
            if (subClass == null)
            {
                return NotFound();
            }

            return View(subClass);
        }

        // GET: SubClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubClassId,SubClassClassId,SubClassName,SubClassDescription,SubClassFeatures")] SubClass subClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subClass);
        }

        // GET: SubClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subClass = await _context.SubClass.FindAsync(id);
            if (subClass == null)
            {
                return NotFound();
            }
            return View(subClass);
        }

        // POST: SubClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubClassId,SubClassClassId,SubClassName,SubClassDescription,SubClassFeatures")] SubClass subClass)
        {
            if (id != subClass.SubClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubClassExists(subClass.SubClassId))
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
            return View(subClass);
        }

        // GET: SubClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subClass = await _context.SubClass
                .FirstOrDefaultAsync(m => m.SubClassId == id);
            if (subClass == null)
            {
                return NotFound();
            }

            return View(subClass);
        }

        // POST: SubClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subClass = await _context.SubClass.FindAsync(id);
            _context.SubClass.Remove(subClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubClassExists(int id)
        {
            return _context.SubClass.Any(e => e.SubClassId == id);
        }
    }
}
