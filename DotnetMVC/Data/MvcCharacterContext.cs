using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotnetMVC.Models;

namespace MvcCharacter.Data
{
    public class MvcCharacterContext : DbContext
    {
        public MvcCharacterContext (DbContextOptions<MvcCharacterContext> options)
            : base(options)
        {
        }

        public DbSet<DotnetMVC.Models.Character> Character { get; set; } = default!;
    }
}
