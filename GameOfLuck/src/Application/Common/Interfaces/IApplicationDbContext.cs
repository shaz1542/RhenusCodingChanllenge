using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Domain.Entities.Bet> Bets { get; }

    DbSet<Player> Players { get; }

    DbSet<Domain.Entities.Game> Games { get; }          

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
