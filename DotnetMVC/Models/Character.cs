using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetMVC.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Campaign { get; set; }
        public int? Health { get; set; }
        public int? Currency { get; set; }
        public string? Items { get; set; } //simplified for now
    }
}