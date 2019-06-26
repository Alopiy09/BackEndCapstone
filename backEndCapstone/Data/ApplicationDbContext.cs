using System;
using System.Collections.Generic;
using System.Text;
using backEndCapstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backEndCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Background> Background { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<CharacterClass> CharacterClass { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Feat> Feat { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<SubClass> SubClass { get; set; }
        public DbSet<FeatCharacter> FeatCharacter { get; set; }
        public DbSet<EquipmentCharacter> EquipmentCharacter { get; set; }

    }
}
