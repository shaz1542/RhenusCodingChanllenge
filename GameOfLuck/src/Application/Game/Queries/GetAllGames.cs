using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Game.Queries;
internal class GetAllGames
{
}


public record GetAllGamesQuery : IRequest<IEnumerable<Domain.Entities.Game>>;

public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<Domain.Entities.Game>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllGamesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Domain.Entities.Game>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_context.Games.ToList().OrderBy(x => x.Created));
    }
}
