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

        /*
                            19      20      21       
                            18      C1      22       
                            17      C2      23
                            16      C3      24
            11  12  13  14  15      C4      25  26  27  28  29
            10  B1  B2  B3  B4              D4  D3  D2  D1  30
            09  08  07  06  05      A4      35  34  33  32  31
                            04      A3      36               
                            03      A2      37             
                            02      A1      38              
                            01      00      39              
                          
            */

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
