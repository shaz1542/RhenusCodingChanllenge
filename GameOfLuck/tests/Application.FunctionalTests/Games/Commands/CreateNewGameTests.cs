using GameOfLuck.Application.Game.Commands;

using static GameOfLuck.Application.FunctionalTests.Testing;

namespace GameOfLuck.Application.FunctionalTests.Games.Commands;
public class CreateNewGameTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateGame()
    {
        //var userId = await RunAsDefaultUserAsync();

        var command = new CreateNewGameCommand
        {
        };

        var gameId = await SendAsync(command);

        var item = await FindAsync<Domain.Entities.Game>(gameId);
        item.Should().NotBeNull();
    }
    [Test]
    public async Task ShouldhaveValidSecretNumber()
    {
        //var userId = await RunAsDefaultUserAsync();
        var command = new CreateNewGameCommand { };
        var gameId = await SendAsync(command);
        var item = await FindAsync<Domain.Entities.Game>(gameId);
        item.Should().NotBeNull();
        item?.GetSecretNumber().Should().BeInRange(0, 9);
    }

}
