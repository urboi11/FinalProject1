using Microsoft.EntityFrameworkCore;
using FinalProject1.Models;
using Microsoft.Net.Http.Headers;

namespace FinalProject1.Data;

public class FinalProjectContext : DbContext
{
    public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options)
    {

    }

    public DbSet<Team> Teams => Set<Team>();
    public DbSet<BestFriend> BestFriends  => Set<BestFriend>();
    public DbSet<BreakfastFood> BreakfastFoods => Set<BreakfastFood>();
    public DbSet<FavoriteMovie> FavoriteMovies => Set<FavoriteMovie>();

    public DbSet<Hobby> Hobbies => Set<Hobby>();
}