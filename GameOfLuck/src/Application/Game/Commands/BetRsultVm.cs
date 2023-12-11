using System.Security.Principal;

namespace GameOfLuck.Application.Game.Commands;

public class BetResultVm
{
    public int betId { get; set; }
    public string? account { get; set; }
    public string? Status { get; set; }
    public string? points { get; set; }
}
