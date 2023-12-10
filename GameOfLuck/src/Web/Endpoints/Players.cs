
using GameOfLuck.Application.Game.Commands;
using GameOfLuck.Application.Game.Queries;
using GameOfLuck.Application.Players.Queries;

namespace GameOfLuck.Web.Endpoints;

public class Players : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateNewPlayer)
            .MapGet(GetAllPlayers);
    }
    public async Task<IEnumerable<Domain.Entities.Player>> GetAllPlayers(ISender sender)
    {
        return await sender.Send(new GetAllPlayersQuery());
    }

    public async Task<int> CreateNewPlayer(ISender sender, CreateNewPlayerCommand command)
    {
        return await sender.Send(command);
    }

}
