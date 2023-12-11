using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Game.Commands;
public record ProcessBetCommand : IRequest<BetResultVm>
{
    public int PlayerId { get; set; }
    public int GameId { get; set; }
    public int betAmount { get; set; }
    public int betNumber { get; set; }
}

public class ProcessBetCommandHandler : IRequestHandler<ProcessBetCommand, BetResultVm>
{
    private readonly IApplicationDbContext _context;

    public ProcessBetCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BetResultVm> Handle(ProcessBetCommand request, CancellationToken cancellationToken)
    {
        BetResultVm result = new BetResultVm();
        var game = _context.Games.Where(x => x.Id == request.GameId).FirstOrDefault();
        var player = _context.Players.Where(x => x.Id == request.PlayerId).First();

        var bet = new Domain.Entities.Bet(request.GameId, request.PlayerId, request.betAmount, request.betNumber);
        
        if (game?.GetSecretNumber() == request.betNumber)
        {
            bet.result = BetResult.Won;
            player.BalancePoints += request.betAmount * 9;
            var betObject = await _context.Bets.AddAsync(bet);
            await _context.SaveChangesAsync(cancellationToken);
            result.betId = betObject.Entity.Id;
            result.Status = "Won";
            result.points = "+" + request.betAmount * 9;
            
        }
        else
        {
            bet.result = BetResult.Lost;
            player.BalancePoints -= request.betAmount;
            var betObject = await _context.Bets.AddAsync(bet);
            await _context.SaveChangesAsync(cancellationToken);
            result.Status = "Lost";
            result.points = request.betAmount * -1 + "";
            result.betId = betObject.Entity.Id;
        }
        result.account = player.BalancePoints.ToString();
        return result;
    }
}
