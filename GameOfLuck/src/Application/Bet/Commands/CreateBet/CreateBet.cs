using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;
using GameOfLuck.Domain.Events;

namespace GameOfLuck.Application.Bet.Commands.CreateBet;
public record CreateBetCommand : IRequest<int>
{
    public int PlayerId { get; init; }

    public int GameId { get; init; }

    public int BetAmmout { get; set; }
    public int BetNumber { get; set; }

}

public class CreateBetCommandHandler : IRequestHandler<CreateBetCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBetCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBetCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Bet
        {
            GameId  = request.GameId,
            PlayerId   = request.PlayerId,
            Ammount=   request.BetAmmout,
            Number  =request.BetNumber
        };

        //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.Bets.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

