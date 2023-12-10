using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Application.Common.Models;
using GameOfLuck.Application.TodoLists.Queries.GetTodos;
using GameOfLuck.Domain.Enums;

namespace GameOfLuck.Application.Bet.Queries;
public record GetBetsByGameIdQuery : IRequest<BetsVm>;
public class GetBetsByGameIdQueryHandler : IRequestHandler<GetBetsByGameIdQuery, BetsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetBetsByGameIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }
    public Task<BetsVm> Handle(GetBetsByGameIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
/*

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return new TodosVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new LookupDto { Id = (int)p, Title = p.ToString() })
                .ToList(),

            Lists = await _context.TodoLists
                .AsNoTracking()
                .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
*/
