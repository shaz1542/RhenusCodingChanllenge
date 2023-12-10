using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;

namespace GameOfLuck.Application.Bet.Queries;
public record GetBetsByPlayerIdQuery : IRequest<BetsVm>;
public class GetBetsByPlayerIdQueryHandler : IRequestHandler<GetBetsByPlayerIdQuery, BetsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetBetsByPlayerIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<BetsVm> Handle(GetBetsByPlayerIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
