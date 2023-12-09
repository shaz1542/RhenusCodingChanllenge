using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLuck.Domain.Entities;
internal class Game
{
    private int randomNumber;
    private List<Player> players = new List<Player>();
    private Random random = new Random();
    public void NewGame()
    {
        players.Clear();
        randomNumber = random.Next(10);
    }
    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player) { players.Remove(player); }

    
}
