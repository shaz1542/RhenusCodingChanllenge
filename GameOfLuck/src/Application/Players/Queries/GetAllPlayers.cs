using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Players.Queries;
internal class GetAllPlayers
{
}


public record GetAllPlayersQuery : IRequest<IEnumerable<Player>>;

public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPlayersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_context.Players.ToList().OrderBy(x => x.Created));
    }
}

