using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLuck.Domain.Events
{
    internal class PlayerPlacedBet : BaseEvent
    {
        public PlayerPlacedBet(Player player)
        {
            Player = player;
        }

        public Player Player { get; }

    }
}
