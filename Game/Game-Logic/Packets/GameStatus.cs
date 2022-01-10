using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Packets;

namespace Game_Logic.Packets
{
    public class GameStatus
    {
        public Cell[] Cells { get; private set; }

        public Player[] Players { get; private set; }
        public DestinationCell[] DestinationCells { get; private set; }

        public GameStatus(Cell[] cells, Player[] players, DestinationCell[] destinationCells)
        {
            this.Cells = cells;
            this.Players = players;
            this.DestinationCells = destinationCells;
        }
    }
}
