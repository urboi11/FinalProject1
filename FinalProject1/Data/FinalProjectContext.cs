using Microsoft.EntityFrameworkCore;
using FinalProject1.Models;

namespace FinalProject1.Data;

public class FinalProjectContext : DbContext
{
    public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options)
    {

    }

    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<BestFriend> BestFriends { get; set; } = null!;
    public DbSet<TeamFavorite> TeamFavorite { get; set; } = default!;
    public DbSet<BreakfastFood> BreakfastFoods => Set<BreakfastFood>();
    public DbSet<FavoriteMovie> FavoriteMovies => Set<FavoriteMovie>();

    public DbSet<Hobby> Hobbies => Set<Hobby>();
}