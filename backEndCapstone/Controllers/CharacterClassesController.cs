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
    public class CharacterClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CharacterClasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CharacterClass.Include(c => c.SubClass);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CharacterClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterClass = await _context.CharacterClass
                .Include(c => c.SubClass)
                .FirstOrDefaultAsync(m => m.CharacterClassId == id);
            if (characterClass == null)
            {
                return NotFound();
            }

            return View(characterClass);
        }

        // GET: CharacterClasses/Create
        public IActionResult Create()
        {
            ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassDescription");
            return View();
        }

        // POST: CharacterClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterClassId,ClassName,ClassDescription,ClassFeatures,Experience,SubClassId")] CharacterClass characterClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassDescription", characterClass.SubClassId);
            return View(characterClass);
        }

        // GET: CharacterClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterClass = await _context.CharacterClass.FindAsync(id);
            if (characterClass == null)
            {
                return NotFound();
            }
            ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassDescription", characterClass.SubClassId);
            return View(characterClass);
        }

        // POST: CharacterClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterClassId,ClassName,ClassDescription,ClassFeatures,Experience,SubClassId")] CharacterClass characterClass)
        {
            if (id != characterClass.CharacterClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterClassExists(characterClass.CharacterClassId))
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
            ViewData["SubClassId"] = new SelectList(_context.SubClass, "SubClassId", "SubClassDescription", characterClass.SubClassId);
            return View(characterClass);
        }

        // GET: CharacterClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterClass = await _context.CharacterClass
                .Include(c => c.SubClass)
                .FirstOrDefaultAsync(m => m.CharacterClassId == id);
            if (characterClass == null)
            {
                return NotFound();
            }

            return View(characterClass);
        }

        // POST: CharacterClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterClass = await _context.CharacterClass.FindAsync(id);
            _context.CharacterClass.Remove(characterClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterClassExists(int id)
        {
            return _context.CharacterClass.Any(e => e.CharacterClassId == id);
        }
    }
}
