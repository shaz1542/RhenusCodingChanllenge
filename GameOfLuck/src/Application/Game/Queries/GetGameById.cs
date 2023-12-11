using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;

namespace GameOfLuck.Application.Game.Queries;

public record GetGameByIdQuery : IRequest<Domain.Entities.Game>
{
    public int Id { get; set; }
};

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Domain.Entities.Game>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGameByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Domain.Entities.Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_context.Games.Where(x => x.Id == request.Id).First());
    }
}
