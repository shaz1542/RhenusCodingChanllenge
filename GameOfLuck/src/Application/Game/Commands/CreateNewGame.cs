using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Game.Commands;

public record CreateNewGameCommand : IRequest<int>
{
    //public string? Title { get; init; }
}

public class CreateNewGameCommandHandler : IRequestHandler<CreateNewGameCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateNewGameCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateNewGameCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Game();

        _context.Games.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
