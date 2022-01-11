using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Enums;
using Game_Logic;

namespace Game_Console
{
    public static class EnumConvertor
    {
        public static FigureEnum IntToFigureEnum(int figureID)
        {
            switch (figureID)
            {
                case 1: return FigureEnum.Figure_1;
                case 2: return FigureEnum.Figure_2;
                case 3: return FigureEnum.Figure_3;
                case 4: return FigureEnum.Figure_4;
                default:
                    throw new Exception("Invalid FigureID");
            }
        }

        public static string GetFigureOfDestiantionCelL(int id, DestinationCell destinationCell)
        {
            var destinationEnum = IntToDestinationCellFigureHoldersEnum(id);
            switch (destinationEnum)
            {
                case DestinationCellFigureHoldersEnum.Place1:
                    return FigureEnumToString(destinationCell.Position_1);
                case DestinationCellFigureHoldersEnum.Place2:
                    return FigureEnumToString(destinationCell.Position_2);
                case DestinationCellFigureHoldersEnum.Place3:
                    return FigureEnumToString(destinationCell.Position_3);
                case DestinationCellFigureHoldersEnum.Place4:
                    return FigureEnumToString(destinationCell.Position_4);
                default:
                    throw new Exception("Invalid Figure Holder Value");
            }
        }

        public static string FigureEnumToString(FigureEnum figureEnum)
        {
            switch (figureEnum)
            {
                case FigureEnum.Figure_1:
                    return "1";
                case FigureEnum.Figure_2:
                    return "2";
                case FigureEnum.Figure_3:
                    return "3";
                case FigureEnum.Figure_4:
                    return "4";
                case FigureEnum.NoFigure:
                    return String.Empty;
                default:
                    throw new Exception("Invalid Figure Enum");
            }
        }

        public static DestinationCellFigureHoldersEnum IntToDestinationCellFigureHoldersEnum(int destination)
        {
            switch (destination)
            {
                case 1:
                    return DestinationCellFigureHoldersEnum.Place1;
                case 2:
                    return DestinationCellFigureHoldersEnum.Place2;
                case 3:
                    return DestinationCellFigureHoldersEnum.Place3;
                case 4:
                    return DestinationCellFigureHoldersEnum.Place4;
                default:
                    throw new Exception("Invalid Destination ID");
            }
        }

        public static int PlayerEnumToInt(PlayerEnum playerEnum)
        {
            switch (playerEnum)
            {
                case PlayerEnum.Player_1:
                    return 1;
                case PlayerEnum.Player_2:
                    return 2;
                case PlayerEnum.Player_3:
                    return 3;
                case PlayerEnum.Player_4:
                    return 4;
                case PlayerEnum.NoPlayer:
                    throw new Exception("Invalid Player Enum");
                default:
                    throw new Exception("Invalid Player Enum");
            }
        }

        public static int FigureEnumToInt(FigureEnum figureEnum)
        {
            switch (figureEnum)
            {
                case FigureEnum.Figure_1:
                    return 1;
                case FigureEnum.Figure_2:
                    return 2;
                case FigureEnum.Figure_3:
                    return 3;
                case FigureEnum.Figure_4:
                    return 4;
                case FigureEnum.NoFigure:
                    throw new Exception("Invalid Figure Enum");
                default:
                    throw new Exception("Invalid Figure Enum");
            }
        }

        public static string FigureListToString(List<FigureEnum> figures)
        {
            var res = String.Empty;
            foreach (var figuresItem in figures)
            {
                var figureInt = FigureEnumToInt(figuresItem);
                res += figureInt.ToString();
                res += " ";
            }

            return res;
        }
    }
}
