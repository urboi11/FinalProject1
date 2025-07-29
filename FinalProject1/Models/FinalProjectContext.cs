using Microsoft.EntityFrameworkCore;

namespace FinalProject1.Models;

public class FinalProjectContext : DbContext
{
    public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options)
    {

    }

    public DbSet<Team> Teams { get; set; } = null!;

    public DbSet<BestFriend> BestFriends { get; set; } = null!;
    
}