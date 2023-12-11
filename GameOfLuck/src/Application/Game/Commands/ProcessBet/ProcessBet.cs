using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Game.Commands.ProcessBet;
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
            _context.Bets.Add(bet);
            player.BalancePoints += request.betAmount * 9;

            result.Status = "Won";
            result.points = "+" + request.betAmount * 9;
        }
        else
        {
            bet.result = BetResult.Lost;
            _context.Bets.Add(bet);
            player.BalancePoints -= request.betAmount;
            result.Status = "Lost";
            result.points = request.betAmount * -1 + "";
        }
        await _context.SaveChangesAsync(cancellationToken);
        result.account = player.BalancePoints.ToString();

        return result;
    }
}
