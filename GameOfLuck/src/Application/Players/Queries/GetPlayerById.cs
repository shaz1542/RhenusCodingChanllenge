using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Players.Queries;

public record GetPlayerByIdQuery : IRequest<Player>
{
    public int Id { get; set; }
}

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlayerByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_context.Players.Where(x => x.Id == request.Id).First());
    }
}

