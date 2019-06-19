using backEndCapstone.Data;
using backEndCapstone.Models;
using backEndCapstone.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backEndCapstone.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CharactersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() =>
            _userManager.GetUserAsync(HttpContext.User);

        [Authorize]
        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Character
                .Include(c => c.Race)
                .Include(c => c.characterClasses)
                .Where(c => c.UserId == user.Id)
                .ToList();


            return View(await _context.Character.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .Include(c => c.Race)
                .Include(c => c.characterClasses)
                .Include(c => c.background)
                .Include(c => c.Feats)
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        [Authorize]
        // GET: Characters/Create
        public IActionResult Create()
        {
            var CCMV = new CreateCharacterViewModel();
            CCMV.Character = new Character();
            var characterRace = _context.Race;
            var characterFeats = _context.Feat;
            var characterBackgrounds = _context.Background;
            var characterClass = _context.CharacterClass;
            List<SelectListItem> RaceSelectListItems = new List<SelectListItem>();
            List<SelectListItem> FeatSelectListItems = new List<SelectListItem>();
            List<SelectListItem> BackgroundSelectListItem = new List<SelectListItem>();
            List<SelectListItem> ClassSelectListItem = new List<SelectListItem>();

            foreach (var race in characterRace)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = race.RaceId.ToString(),
                    Text = race.RaceType
                };
                RaceSelectListItems.Add(li);
            }
            foreach (var feat in characterFeats)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = feat.FeatId.ToString(),
                    Text = feat.Description
                };
                FeatSelectListItems.Add(li);
            }
            foreach (var background in characterBackgrounds)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = background.BackgroundId.ToString(),
                    Text = background.description
                };
                BackgroundSelectListItem.Add(li);
            }
            foreach (var CharacterClass in characterClass)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = CharacterClass.CharacterClassId.ToString(),
                    Text = CharacterClass.ClassName
                };
                ClassSelectListItem.Add(li);
            }
            CCMV.CharacterClass = ClassSelectListItem;
            CCMV.Backgrounds = BackgroundSelectListItem;
            CCMV.Feats = FeatSelectListItems;
            CCMV.Races = RaceSelectListItems;
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View(CCMV);

        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCharacterViewModel model)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            ModelState.Remove("Races");
            ModelState.Remove("Feats");
            ModelState.Remove("Backgrounds");
            ModelState.Remove("CharacterClass");
            var user = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                model.Character.User = user;
                model.Character.UserId = user.Id;
                _context.Add(model.Character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", model.Character.UserId);
            return View(model);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var UCVM = new UpdateCharacterViewModel();

            UCVM.Character = await _context.Character.FindAsync(id);

            var characterFeats = _context.Feat;
            var characterEquipment = _context.Equipment;

            List<SelectListItem> EquipmentSelectListItems = new List<SelectListItem>();
            List<SelectListItem> FeatSelectListItems = new List<SelectListItem>();

            foreach (var equipment in characterEquipment)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = equipment.EquipmentId.ToString(),
                    Text = equipment.EquipmentName
                };
                EquipmentSelectListItems.Add(li);
            }

            foreach (var feat in characterFeats)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = feat.FeatId.ToString(),
                    Text = feat.Description
                };
                FeatSelectListItems.Add(li);
            }

            UCVM.Equipment = EquipmentSelectListItems;
            UCVM.Feats = FeatSelectListItems;

            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View(UCVM);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Character,CharacterClassId, CharacterId, Name, Alignment, Strength, Dexterity, Constitution, Inteligence, Wisdom, Charisma, Equipment, Feats, EquipmentId, FeatsId")] UpdateCharacterViewModel model)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            ModelState.Remove("Races");
            ModelState.Remove("Feats");
            ModelState.Remove("Backgrounds");
            ModelState.Remove("CharacterClass"); 

            

            if (id != model.Character.CharacterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var characterUserId = model.Character.UserId;
                    var user = await GetCurrentUserAsync();

                    model.Character.UserId = user.Id;
                    _context.Update(model.Character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(model.Character.CharacterId))
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
            return View(model);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Character.FindAsync(id);
            _context.Character.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.CharacterId == id);
        }
    }
}
