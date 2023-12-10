using GameOfLuck.Application.Game.Commands;
using GameOfLuck.Application.Game.Queries;


namespace GameOfLuck.Web.Endpoints;

public class Game : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateNewGame)
            .MapGet(GetAllGames);
            
    }
    public async Task<IEnumerable<Domain.Entities.Game>> GetAllGames(ISender sender)
    {
        return await sender.Send(new GetAllGamesQuery());
    }

    public async Task<int> CreateNewGame(ISender sender, CreateNewGameCommand command)
    {
        return await sender.Send(command);
    }

}
