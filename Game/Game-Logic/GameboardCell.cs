using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class GameboardCell
    {
        public Player Player { get; set; }
        public Figure Figure { get; set; }
        public int FigureID { get; set; }

        public int CellID { get; private set; }

        public GameboardCell(int id)
        {
            this.CellID = id;
        }

        public void SetPlayerAndFigure(Player player, int figureID)
        {
            this.Player = player;
            this.FigureID = figureID;
        }

        public void RemovePlayer()
        {
            this.Player = null; 
        }

        public bool HasPlayer()
        {
            if (this.Player == null) { return false; }

            return true;
        }
    }
}
