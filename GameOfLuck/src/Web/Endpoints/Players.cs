
using GameOfLuck.Application.Players.Commands;
using GameOfLuck.Application.Players.Queries;

namespace GameOfLuck.Web.Endpoints;

public class Players : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateNewPlayer)
            .MapGet(GetAllPlayers)
            .MapGet(GetPlayerById,"{id}");
    }
    public async Task<IEnumerable<Domain.Entities.Player>> GetAllPlayers(ISender sender)
    {
        return await sender.Send(new GetAllPlayersQuery());
    }


    public async Task<Domain.Entities.Player> GetPlayerById(ISender sender, [AsParameters] GetPlayerByIdQuery query)
    {
        return await sender.Send(query);
    }
    public async Task<int> CreateNewPlayer(ISender sender, CreateNewPlayerCommand command)
    {
        return await sender.Send(command);
    }

}
