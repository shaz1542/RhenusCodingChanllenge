using System.Security.Principal;

namespace GameOfLuck.Application.Game.Commands;

public class BetResult
{
    public string? account { get; set; }
    public string? Status { get; set; }
    public int points { get; set; }
}
