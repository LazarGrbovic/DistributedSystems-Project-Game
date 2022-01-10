using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Packets;
using Game_Logic.Enums;

namespace Game_Console
{
    public class Renderer
    {
        public void RenderGameboard(GameStatus gameStatus)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            int xPos = 0;
            int yPos = 0;
            
            for (int i = 0; i < 40; i++)
            {
                //var cell = gameStatus.Cells[i];
                this.GetCoordinatesOfCell(i, ref xPos, ref yPos);
                //var color = this.GetColor(i);

                this.RenderCell(xPos, yPos, this.GetColor(gameStatus.Cells[i].Player), this.GetFigure(i, gameStatus));
            }

            /*
            Console.WriteLine("                19      20      21       ");  
            Console.WriteLine("                18      C1      22       ");  
            Console.WriteLine("                17      C2      23");  
            Console.WriteLine("                16      C3      24");  
            Console.WriteLine("11  12  13  14  15      C4      25  26  27  28  29");  
            Console.WriteLine("10  B1  B2  B3  B4              D4  D3  D2  D1  30");  
            Console.WriteLine("09  08  07  06  05      A4      35  34  33  32  31");  
            Console.WriteLine("                04      A3      36               ^");  
            Console.WriteLine("                03      A2      37               ");
            Console.WriteLine("                02      A1      38                ");
            Console.WriteLine("                01      00      39                ");
            Console.WriteLine("                ");
            */

            //this.RenderCell(4, 10, "X");

            yPos = Console.CursorTop + 2;
            Console.SetCursorPosition(10, yPos);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Player 1:");

            Console.SetCursorPosition(30, yPos);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Player 2:");

            Console.SetCursorPosition(50, yPos);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Player 3:");

            Console.SetCursorPosition(70, yPos);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Player 4:");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, yPos + 2);
            Console.Write(EnumConvertor.FigureListToString(gameStatus.Players[0].FiguresAtStart));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(30, yPos + 2);
            Console.Write(EnumConvertor.FigureListToString(gameStatus.Players[1].FiguresAtStart));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(50, yPos + 2);
            Console.Write(EnumConvertor.FigureListToString(gameStatus.Players[2].FiguresAtStart));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(70, yPos + 2);
            Console.Write(EnumConvertor.FigureListToString(gameStatus.Players[3].FiguresAtStart));
        }

        public FigureEnum GetUserInput(int dice, PlayerEnum playerID, List<FigureEnum> figures)
        {
            Console.ForegroundColor= ConsoleColor.Gray;
            Console.SetCursorPosition(2, 52);
            Console.WriteLine($"Player {playerID}, Please Select Figure To Make {dice} steps [Figures Available: {EnumConvertor.FigureListToString(figures)}]");
            var input = Console.ReadLine();
            return EnumConvertor.IntToFigureEnum(int.Parse(input));
        }

        private ConsoleColor GetColor(PlayerEnum player)
        {
            switch (player)
            {
                case PlayerEnum.Player_1:
                    return ConsoleColor.Cyan;
                case PlayerEnum.Player_2:
                    return ConsoleColor.Magenta;
                case PlayerEnum.Player_3:
                    return ConsoleColor.Blue;
                case PlayerEnum.Player_4:
                    return ConsoleColor.Green;
                case PlayerEnum.NoPlayer:
                    return ConsoleColor.Gray; ;
                default:
                    throw new Exception("Invalid Player Enum");
            }
        }

        /*
        private void RenderManuallyGameboard()
        {
            int xPos;
            int yPos;

            // TopLeftVertical
            xPos = 31;
            yPos = 4;

            for (int i = 0; i < 5; i++)
            {
                this.RenderCell(xPos, yPos);
                yPos += 2;
            }


            xPos = 11;
            yPos = Console.CursorTop - 3;
            for (int i = 0; i < 4; i++)
            {
                this.RenderCell(xPos, yPos);
                xPos += 5;
            }

            xPos = 11;
            yPos = Console.CursorTop - 1;

            for (int i = 0; i < 5; i++)
            {
                this.RenderCell(xPos, yPos);
                xPos += 5;
            }

            xPos = 11;
            yPos = Console.CursorTop - 1;

            for (int i = 0; i < 5; i++)
            {
                this.RenderCell(xPos, yPos);
                xPos += 5;
            }

            xPos = 31;
            yPos = Console.CursorTop - 1;

            for (int i = 0; i < 5; i++)
            {
                this.RenderCell(xPos, yPos);
                yPos += 2;
            }
        }
        */

        private void RenderCell(int x, int y, ConsoleColor foreground, string figure)
        {
            
            Console.SetCursorPosition(x, y);
            
            Console.WriteLine("---------");
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.Write("|   ");

            Console.ForegroundColor = foreground;
            Console.Write(figure.PadLeft(1));
            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("   |");
            
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine("---------");
        }

        private string GetFigure(int count, GameStatus gameStatus)
        {
            if (gameStatus.Cells[count].Player == PlayerEnum.NoPlayer)  { return String.Empty;  }

            switch (gameStatus.Cells[count].Figure)
            {
                case FigureEnum.Figure_1:
                    return "1";
                case FigureEnum.Figure_2:
                    return "2";
                case FigureEnum.Figure_3: 
                     return "3";
                case FigureEnum.Figure_4: 
                    return "4";
                default:
                    throw new Exception("Invalid FigureID");
            }
        }

        private void GetCoordinatesOfCell(int id, ref int x, ref int y)
        {
            switch (id)
            {
                case 0:
                    x = 44;
                    y = 42;
                    break;
                case 1:
                    x = 36;
                    y = 42;
                    break;
                case 2:
                    x = 36;
                    y = 40;
                    break;
                case 3:
                    x = 36;
                    y = 38;
                    break;
                case 4:
                    x = 36;
                    y = 36;
                    break;
                case 5:
                    x = 36;
                    y = 34;
                    break;
                case 6:
                    x = 28;
                    y = 34;
                    break;
                case 7:
                    x = 20;
                    y = 34;
                    break;
                case 8:
                    x = 12;
                    y = 34;
                    break;
                case 9:
                    x = 4;
                    y = 34;
                    break;
                case 10:
                    x = 4;
                    y = 32;
                    break;

                case 11:
                    x = 4;
                    y = 30;
                    break;
                case 12:
                    x = 12;
                    y = 30;
                    break;
                case 13:
                    x = 20;
                    y = 30;
                    break;
                case 14:
                    x = 28;
                    y = 30;
                    break;
                case 15:
                    x = 36;
                    y = 30;
                    break;
                case 16:
                    x = 36;
                    y = 28;
                    break;
                case 17:
                    x = 36;
                    y = 26;
                    break;
                case 18:
                    x = 36;
                    y = 24;
                    break;
                case 19:
                    x = 36;
                    y = 22;
                    break;
                case 20:
                    x = 44;
                    y = 22;
                    break;
                case 21:
                    x = 52;
                    y = 22;
                    break;

                case 22:
                    x = 52;
                    y = 24;
                    break;
                case 23:
                    x = 52;
                    y = 26;
                    break;
                case 24:
                    x = 52;
                    y = 28;
                    break;
                case 25:
                    x = 52;
                    y = 30;
                    break;
                case 26:
                    x = 60;
                    y = 30;
                    break;
                case 27:
                    x = 68;
                    y = 30;
                    break;
                case 28:
                    x = 76;
                    y = 30;
                    break;
                case 29:
                    x = 84;
                    y = 30;
                    break;
                case 30:
                    x = 84;
                    y = 32;
                    break;
                case 31:
                    x = 84;
                    y = 34;
                    break;
                case 32:
                    x = 76;
                    y = 34;
                    break;

                case 33:
                    x = 68;
                    y = 34;
                    break;
                case 34:
                    x = 60;
                    y = 34;
                    break;
                case 35:
                    x = 52;
                    y = 34;
                    break;
                case 36:
                    x = 52;
                    y = 36;
                    break;
                case 37:
                    x = 52;
                    y = 38;
                    break;
                case 38:
                    x = 52;
                    y = 40;
                    break;
                case 39:
                    x = 52;
                    y = 42;
                    break;
                default:
                    break;
            }
        }

        /*
        private void GetCoordinatesOfCell(int id, ref int x, ref int y)
        {
            switch (id)
            {
                case 0:
                    x = 36;
                    y = 42;
                    break;
                case 1:
                    x = 36;
                    y = 40;
                    break;
                case 2:
                    x = 36;
                    y = 38;
                    break;
                case 3:
                    x = 36;
                    y = 36;
                    break;
                case 4:
                    x = 36;
                    y = 34;
                    break;
                case 5:
                    x = 28;
                    y = 34;
                    break;
                case 6:
                    x = 20;
                    y = 34;
                    break;
                case 7:
                    x = 12;
                    y = 34;
                    break;
                case 8:
                    x = 4;
                    y = 34;
                    break;
                case 9:
                    x = 4;
                    y = 32;
                    break;
                case 10:
                    x = 4;
                    y = 30;
                    break;

                case 11:
                    x = 12;
                    y = 30;
                    break;
                case 12:
                    x = 20;
                    y = 30;
                    break;
                case 13:
                    x = 28;
                    y = 30;
                    break;
                case 14:
                    x = 36;
                    y = 30;
                    break;
                case 15:
                    x = 36;
                    y = 28;
                    break;
                case 16:
                    x = 36;
                    y = 26;
                    break;
                case 17:
                    x = 36;
                    y = 24;
                    break;
                case 18:
                    x = 36;
                    y = 22;
                    break;
                case 19:
                    x = 44;
                    y = 22;
                    break;
                case 20:
                    x = 52;
                    y = 22;
                    break;
                case 21:
                    x = 52;
                    y = 24;
                    break;

                case 22:
                    x = 52;
                    y = 26;
                    break;
                case 23:
                    x = 52;
                    y = 28;
                    break;
                case 24:
                    x = 52;
                    y = 30;
                    break;
                case 25:
                    x = 60;
                    y = 30;
                    break;
                case 26:
                    x = 68;
                    y = 30;
                    break;
                case 27:
                    x = 76;
                    y = 30;
                    break;
                case 28:
                    x = 84;
                    y = 30;
                    break;
                case 29:
                    x = 84;
                    y = 32;
                    break;
                case 30:
                    x = 84;
                    y = 34;
                    break;
                case 31:
                    x = 76;
                    y = 34;
                    break;
                case 32:
                    x = 68;
                    y = 34;
                    break;

                case 33:
                    x = 60;
                    y = 34;
                    break;
                case 34:
                    x = 52;
                    y = 34;
                    break;
                case 35:
                    x = 52;
                    y = 36;
                    break;
                case 36:
                    x = 52;
                    y = 38;
                    break;
                case 37:
                    x = 52;
                    y = 40;
                    break;
                case 38:
                    x = 52;
                    y = 42;
                    break;
                case 39:
                    x = 52;
                    y = 44;
                    break;
                default:
                    break;
            }
        }
        */
    }
}
