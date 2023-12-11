using System.Reflection;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;
using GameOfLuck.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameOfLuck.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Player> Players => Set<Player>();

    public DbSet<Bet> Bets => Set<Bet>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
