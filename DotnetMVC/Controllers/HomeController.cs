using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotnetMVC.Models;
using MvcCharacter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotnetMVC.Controllers;

public class HomeController : Controller
{
    private readonly MvcCharacterContext _context;

        public HomeController(MvcCharacterContext context)
        {
            _context = context;
        }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Characters(string CharacterCampaign, string searchString)
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

    public IActionResult Campaigns()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
