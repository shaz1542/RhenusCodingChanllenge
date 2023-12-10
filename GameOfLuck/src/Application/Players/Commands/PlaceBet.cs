using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Domain.Entities;
using GameOfLuck.Domain.Events;

namespace GameOfLuck.Application.Players.Commands;
internal class PlaceBet
{
    public record PlaceBetCommand : IRequest<int>
    {
        public int betAmmount { get; init; }

        public int betNumber { get; init; }
    }

    public class PlaceBetCommandHandler : IRequestHandler<PlaceBetCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public PlaceBetCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(PlaceBetCommand request, CancellationToken cancellationToken)
        {
            
            var entity = new TodoItem
            {
                //ListId = request.ListId,
                //Title = request.Title,
                Done = false
            };

            entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}
