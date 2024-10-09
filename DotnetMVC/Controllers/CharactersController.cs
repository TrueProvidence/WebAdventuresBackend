using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotnetMVC.Models;
using MvcCharacter.Data;

namespace DotnetMVC.Controllers
{
    public class CharactersController : Controller
    {
        private readonly MvcCharacterContext _context;

        public CharactersController(MvcCharacterContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index(string CharacterCampaign, string searchString)
{
    if (_context.Character == null)
    {
        return Problem("Entity set 'MvcCharacterContext.Character'  is null.");
    }

    // Use LINQ to get list of Campaigns.
    IQueryable<string> CampaignQuery = from m in _context.Character
                                    orderby m.Campaign
                                    select m.Campaign;
    var Characters = from m in _context.Character
                 select m;

    if (!string.IsNullOrEmpty(searchString))
    {
        Characters = Characters.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper()));
    }

    if (!string.IsNullOrEmpty(CharacterCampaign))
    {
        Characters = Characters.Where(x => x.Campaign == CharacterCampaign);
    }

    var characterCampaignVM = new CharacterCampaignViewModel
    {
        Campaigns = new SelectList(await CampaignQuery.Distinct().ToListAsync()),
        Characters = await Characters.ToListAsync()
    };

    return View(characterCampaignVM);
    }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Health,Currency,Items")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Health,Currency,Items")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
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
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (character != null)
            {
                _context.Character.Remove(character);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.Id == id);
        }
    }
}
