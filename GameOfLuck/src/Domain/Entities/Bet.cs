using System;


namespace GameOfLuck.Domain.Entities;
public class Bet : BaseAuditableEntity
{

    public int BetId { get; set; }
    public int Ammount { get; set; }
    public int Number { get; set; }
    public int GameId { get; set; }

    public BetResult result { get; set; }
    public int PlayerId { get; set; }


    public Bet(int gameId, int playerId, int ammount, int number)
    {
        this.GameId = gameId;
        this.PlayerId = PlayerId;
        this.Ammount = ammount;
        this.Number = number;
    }
    public Bet() { }
}
public enum BetResult
{
    Lost,
    Won
}
