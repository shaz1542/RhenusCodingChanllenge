﻿using GameOfLuck.Application.Common.Behaviours;
using GameOfLuck.Application.Common.Interfaces;
using GameOfLuck.Application.Game.Commands;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GameOfLuck.Application.UnitTests.Common.Behaviours;
public class RequestLoggerTests
{
    private Mock<ILogger<CreateNewGameCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateNewGameCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateNewGameCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateNewGameCommand {  }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateNewGameCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateNewGameCommand {}, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
