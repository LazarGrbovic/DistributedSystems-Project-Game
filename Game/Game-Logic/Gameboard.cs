using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Enums;

namespace Game_Logic
{
    public class Gameboard
    {
        public Cell[] Cells { get; private set; }

        public int Player_1_DestinationEntry { get { return 00; } }
        public int Player_2_DestinationEntry { get { return 10; } }
        public int Player_3_DestinationEntry { get { return 20; } }
        public int Player_4_DestinationEntry { get { return 30; } }
        public int Player_1_StartingPos { get { return 01; } }
        public int Player_2_StartingPos { get { return 11; } }
        public int Player_3_StartingPos { get { return 21; } }
        public int Player_4_StartingPos { get { return 31; } }

        public int GetPlayerStartingPosition(PlayerEnum playerEnum)
        {
            switch (playerEnum)
            {
                case PlayerEnum.Player_1:
                    return this.Player_1_StartingPos;
                case PlayerEnum.Player_2:
                    return this.Player_2_StartingPos;
                case PlayerEnum.Player_3:
                    return this.Player_3_StartingPos;
                case PlayerEnum.Player_4:
                    return this.Player_4_StartingPos;
                case PlayerEnum.NoPlayer:
                    throw new Exception("Invalid PlayerID");
                default:
                    throw new Exception("Invalid PlayerID");
            }
        }

        public int GetPosOfPlayersFigure(PlayerEnum player, FigureEnum figure)
        {
            foreach (var cell in this.Cells)
            {
                if (cell.Player == player && cell.Figure == figure) { return cell.ID; }
            }
            
            throw new Exception("Invalid PlayerEnum or FigureEnum");
        }


        public Gameboard()
        {
            this.Cells = new Cell[40];
            for (int i = 0; i < 40; i++)
            {
                this.Cells[i] = new Cell(i);
            }
        }
    }
}
