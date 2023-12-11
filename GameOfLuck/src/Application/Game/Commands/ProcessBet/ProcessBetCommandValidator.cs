using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Application.TodoLists.Commands.CreateTodoList;
using GameOfLuck.Application.TodoLists.Commands.UpdateTodoList;
using Microsoft.EntityFrameworkCore;

namespace GameOfLuck.Application.Game.Commands.ProcessBet;
public class ProcessBetCommandValidator : AbstractValidator<ProcessBetCommand>
{
    private readonly IApplicationDbContext _context;

    public ProcessBetCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.betNumber)
            .InclusiveBetween(0, 9)
                .WithMessage("'{PropertyName}' must be between 0-9 .")
                .WithErrorCode("Invalid Bet");

        RuleFor(v => v.PlayerId)
               .NotNull()
               .MustAsync(PlayerExist)
                .WithMessage("'{PropertyName}' Does not exist")
                .WithErrorCode("Invalid {PropertyName}");


        RuleFor(v => v.GameId)
               .NotNull()
               .MustAsync(GameExist)
                .WithMessage("'{PropertyName}' Does not exist")
                .WithErrorCode("Invalid {PropertyName}");

        RuleFor(v => v.betAmount)
            .MustAsync(MustBeLessThenBalance)
                .WithMessage("'{PropertyName}' must be Less then balance .")
                .WithErrorCode("Invalid Bet amount");

    }
    private async Task<bool> MustBeLessThenBalance(ProcessBetCommand model, int amount, CancellationToken token)
    {
        var player = await _context.Players.Where(x => x.Id == model.PlayerId).FirstOrDefaultAsync();
        return player?.BalancePoints >= amount;
    }
    private async Task<bool> PlayerExist(int playerId, CancellationToken token)
    {
        return (await _context.Players.Where(x => x.Id == playerId).FirstOrDefaultAsync()) != null ? true : false;
    }
    private async Task<bool> GameExist(int gameId, CancellationToken token)
    {
        return (await _context.Games.Where(x => x.Id == gameId).FirstOrDefaultAsync()) != null ? true : false;
    }
}
