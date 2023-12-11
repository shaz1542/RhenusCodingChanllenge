using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLuck.Domain.Entities;
public class Game : BaseAuditableEntity
{
    private int randomNumber { get; set; }
    public IList<Player> players { get; private set; } = new List<Player>();

    public IList<Bet> Bets { get; private set; } = new List<Bet>();

    private Random random = new Random();

    public void GenerateRandomNumber() => randomNumber = random.Next(10);


    public void AddPlayer(Player player) => players.Add(player);

    public void RemovePlayer(Player player) => players.Remove(player);

    public int GetSecretNumber() => randomNumber;
}
