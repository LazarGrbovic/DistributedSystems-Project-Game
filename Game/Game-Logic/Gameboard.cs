using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Gameboard
    {
        public int Player_1_DestinationEntry { get { return 00; } } 
        public int Player_2_DestinationEntry { get { return 10; }}
        public int Player_3_DestinationEntry { get { return 20; }}
        public int Player_4_DestinationEntry { get { return 30; }}        
        public int Player_1_StartingPos { get { return 01; }}
        public int Player_2_StartingPos { get { return 11; }}
        public int Player_3_StartingPos { get { return 21; }}
        public int Player_4_StartingPos { get { return 31; }}

        #region Game Board Field With Numbered Fields
        /*

        B B             19      20      21<   C C
        B B             18      C1      22    C C 
                        17      C2      23
        V               16      C3      24
        11  12  13  14  15      C4      25  26  27  28  29      
        10  B1  B2  B3  B4              D4  D3  D2  D1  30
        09  08  07  06  05      A4      35  34  33  32  31
                        04      A3      36               ^    
                        03      A2      37              
                        02      A1      38            D  D 
          A A         > 01      00      39            D  D 
          A A           
        */
        #endregion

        public GameboardCell[] Cells { get; private set; }

        public Gameboard()
        {
            this.Cells = new GameboardCell[40];  
            
            for (int i = 0; i < 40; i++) 
            { this.Cells[i] = new GameboardCell(i); }
        }

        public GameboardCell GetCellByFigureFromPlayer(int figureID, int playerID)
        {
            for (int i = 0; i < 40; i++)
            {
                if (this.Cells[i].Player.ID == playerID && this.Cells[i].Figure.FigureID == figureID)
                {
                    return this.Cells[i];
                }
            }

            throw new Exception("Invalid FigureID or PlayerID");
        }

        public GameboardCell GetCellByID(int cellID)
        {
            for (int i = 0; i < 40; i++)
            {
                if (this.Cells[i].CellID == cellID) { return this.Cells[i]; }
            }

            throw new Exception("Nonexisting Cell");
        }

        public int GetStartingPositionOfPlayer(int playerID)
        {
            switch (playerID)
            {
                case 1:
                    return 1;
                case 2:
                    return 11;
                case 3:
                    return 21;
                case 4:
                    return 31;                        
                default:
                    throw new Exception("InvalidPayerID");
            }
        }
    }
}
