using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotnetMVC.Models
{
    public class CharacterCampaignViewModel
    {
        public List<Character>? Characters { get; set; }
        public SelectList? Campaigns { get; set; }
        public string? CharacterCampaign { get; set; }
        public string? SearchString { get; set; }
    }
}