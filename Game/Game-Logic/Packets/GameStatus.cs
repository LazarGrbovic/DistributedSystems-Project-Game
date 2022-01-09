using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic.Packets
{
    public class GameStatus
    {
        public GameboardCell[] Cells { get; private set; }
        public Player[] Players { get; private set; }

        public GameStatus(GameboardCell[] cells, Player[] players)
        {
            this.Cells = cells;
            this.Players = players;
        }
    }
}
