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
    public class BackgroundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BackgroundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Backgrounds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Background.ToListAsync());
        }

        // GET: Backgrounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background
                .FirstOrDefaultAsync(m => m.BackgroundId == id);
            if (background == null)
            {
                return NotFound();
            }

            return View(background);
        }

        // GET: Backgrounds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Backgrounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BackgroundId,CharacterId,description,backgroundAbilities")] Background background)
        {
            if (ModelState.IsValid)
            {
                _context.Add(background);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(background);
        }

        // GET: Backgrounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background.FindAsync(id);
            if (background == null)
            {
                return NotFound();
            }
            return View(background);
        }

        // POST: Backgrounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BackgroundId,CharacterId,description,backgroundAbilities")] Background background)
        {
            if (id != background.BackgroundId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(background);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackgroundExists(background.BackgroundId))
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
            return View(background);
        }

        // GET: Backgrounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background
                .FirstOrDefaultAsync(m => m.BackgroundId == id);
            if (background == null)
            {
                return NotFound();
            }

            return View(background);
        }

        // POST: Backgrounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var background = await _context.Background.FindAsync(id);
            _context.Background.Remove(background);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BackgroundExists(int id)
        {
            return _context.Background.Any(e => e.BackgroundId == id);
        }
    }
}
