using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic.Enums
{
    public static class EnumConverter
    {
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
                    throw new Exception("Invalid PlayerEnum");
                default:
                    throw new Exception("Invalid PlayerEnum");
            }
        }

        public static int FigureEnumToInt(FigureEnum playerEnum)
        {
            switch (playerEnum)
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
                    throw new Exception("Invalid FigureEnum");
                default:
                    throw new Exception("Invalid FigureEnum");
            }
        }

        public static PlayerEnum IntToPlayerEnum(int id)
        {
            switch (id)
            {
                case 1:
                    return PlayerEnum.Player_1;
                case 2:
                    return PlayerEnum.Player_2;
                case 3:
                    return PlayerEnum.Player_3;
                case 4:
                    return PlayerEnum.Player_4;
                default:
                    throw new Exception("Invalid PlayerID");
            }
        }

        public static FigureEnum IntToFigureEnum(int id)
        {
            switch (id)
            {
                case 1:
                    return FigureEnum.Figure_1;
                case 2:
                    return FigureEnum.Figure_2;
                case 3:
                    return FigureEnum.Figure_3;
                case 4:
                    return FigureEnum.Figure_4;
                default:
                    throw new Exception("Invalid PlayerID");
            }
        }
    }
}
