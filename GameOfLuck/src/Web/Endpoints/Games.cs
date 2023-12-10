using GameOfLuck.Application.Game.Commands;
using GameOfLuck.Application.Game.Queries;
using GameOfLuck.Application.TodoLists.Commands.CreateTodoList;
using GameOfLuck.Domain.Entities;


namespace GameOfLuck.Web.Endpoints;

public class Games : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            //.Map(CreateNewGame)
            .MapPost(ProcessBet)
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


    public async Task<BetResultVm> ProcessBet(ISender sender, ProcessBetCommand command)
    {
        return await sender.Send(command);
    }

}
