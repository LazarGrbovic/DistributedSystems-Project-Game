using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Figure
    {
        public int PlayerID { get; set; }
        public int FigureID { get; set; }

        public Figure(int playerID, int figureID)
        {
            this.FigureID = figureID;   
            this.PlayerID = playerID;    
        }
    }
}
