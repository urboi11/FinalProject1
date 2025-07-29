using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Models;

namespace FinalProject1.Data
{
    public class FinalProject1Context : DbContext
    {
        public FinalProject1Context (DbContextOptions<FinalProject1Context> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeamFavorite>().HasData(
                new TeamFavorite { Id = 1, Name = "Alice", FavColor = "Blue", FavAnimal = "Dog", FavNumber = 7, FavSeason = "Spring" },
                new TeamFavorite { Id = 2, Name = "Bob", FavColor = "Green", FavAnimal = "Cat", FavNumber = 3, FavSeason = "Summer" }
                );
        }

        public DbSet<FinalProject1.Models.TeamFavorite> TeamFavorite { get; set; } = default!;
    }
}
