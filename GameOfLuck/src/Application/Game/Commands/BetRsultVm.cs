using System.Security.Principal;

namespace GameOfLuck.Application.Game.Commands;

public class BetResultVm
{
    public string? account { get; set; }
    public string? Status { get; set; }
    public int points { get; set; }
}
