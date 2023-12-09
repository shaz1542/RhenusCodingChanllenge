using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLuck.Domain.Entities;
internal class Player
{
    public int id { get; set; }
    public int name { get; set; }
    public int BalancePoints { get; set; }

    public Player() { 
        BalancePoints = 10000;
    }

}
