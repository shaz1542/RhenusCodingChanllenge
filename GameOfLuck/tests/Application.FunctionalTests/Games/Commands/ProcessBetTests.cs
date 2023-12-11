using GameOfLuck.Application.Common.Exceptions;
using GameOfLuck.Application.Game.Commands;
using GameOfLuck.Application.Game.Commands.CreateNewGame;
using GameOfLuck.Application.Game.Commands.ProcessBet;
using GameOfLuck.Application.TodoItems.Commands.CreateTodoItem;
using GameOfLuck.Application.TodoItems.Commands.UpdateTodoItemDetail;
using GameOfLuck.Application.TodoLists.Commands.CreateTodoList;
using GameOfLuck.Domain.Entities;
using GameOfLuck.Domain.Enums;
using static System.Net.Mime.MediaTypeNames;
using static GameOfLuck.Application.FunctionalTests.Testing;

namespace GameOfLuck.Application.FunctionalTests.Games.Commands;
public class ProcessBetTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new ProcessBetCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }


    [Test]
    public async Task InvalidUserPlayerShouldThrowExceoption()
    {
        //var userId = await RunAsDefaultUserAsync();
        var playerId = 1;
        var gameId = await SendAsync(new CreateNewGameCommand { });
        var game = FindAsync<Domain.Entities.Game>(gameId).Result;

        if (game != null)
        {
            var command = new ProcessBetCommand { PlayerId = playerId, GameId = gameId, betAmount = 10, betNumber = game.GetSecretNumber() };

            await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }
    }

    [Test]
    public async Task InvalidGameShouldThrowExceoption()
    {
        //var userId = await RunAsDefaultUserAsync();
        var playerId = await SendAsync(new CreateNewPlayerCommand { Name = "Test Player" });
        var gameId = 1;
        var player = FindAsync<Domain.Entities.Player>(playerId).Result;

        var command = new ProcessBetCommand { PlayerId = playerId, GameId = gameId, betAmount = 10, betNumber = 1 };

        await FluentActions.Invoking(() =>
        SendAsync(command)).Should().ThrowAsync<ValidationException>();

    }

    [Test]
    public async Task InvalidBetAmoutShouldThrowExceoption()
    {
        //var userId = await RunAsDefaultUserAsync();

        var playerId = await SendAsync(new CreateNewPlayerCommand { Name = "Test Player" });
        var player = FindAsync<Domain.Entities.Game>(playerId).Result;
        var gameId = await SendAsync(new CreateNewGameCommand { });
        var game = FindAsync<Domain.Entities.Game>(gameId).Result;

        if (game != null)
        {
            var command = new ProcessBetCommand { PlayerId = playerId, GameId = gameId, betAmount = 10000000, betNumber = game.GetSecretNumber() };
            await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }
    }

    [Test]
    public async Task ShouldProcessBetSuccessFully()
    {
        //var userId = await RunAsDefaultUserAsync();
        int betAmount = 10;

        var playerId = await SendAsync(new CreateNewPlayerCommand
        {
            Name = "Test Player"
        });
        var gameId = await SendAsync(new CreateNewGameCommand
        {
        });
        var game = FindAsync<Domain.Entities.Game>(gameId).Result;

        if (game != null)
        {
            var command = new ProcessBetCommand { PlayerId = playerId, GameId = gameId, betAmount = betAmount, betNumber = game.GetSecretNumber() };

            var responce = await SendAsync(command);

            var gameupdated = await FindAsync<Domain.Entities.Game>(gameId);
            gameupdated.Should().NotBeNull();
            gameupdated?.GetSecretNumber().Should().BeInRange(0, 9);
            responce.Status.Should().BeEquivalentTo("Won");
            responce.account.Should().BeEquivalentTo("10090");
            responce.points.Should().BeEquivalentTo("+90");

            var bet = await FindAsync<Domain.Entities.Bet>(responce.betId);
            bet.Should().NotBeNull();

            bet?.PlayerId.Should().Be(playerId);
            bet?.GameId.Should().Be(gameId);
            bet?.Number.Should().Equals(gameupdated?.GetSecretNumber());
            bet?.Ammount.Should().Equals(betAmount);
        }
    }

}
