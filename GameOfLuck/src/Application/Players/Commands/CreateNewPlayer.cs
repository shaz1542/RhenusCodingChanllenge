using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Players.Commands;

public record CreateNewPlayerCommand : IRequest<int>
{
    public string? Name { get; set; }
}

public class CreateNewPlayerCommandHandler : IRequestHandler<CreateNewPlayerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateNewPlayerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateNewPlayerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Player
        {
            Name = request.Name
        };
        _context.Players.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
