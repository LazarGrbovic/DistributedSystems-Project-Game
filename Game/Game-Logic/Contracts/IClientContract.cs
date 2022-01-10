using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Packets;
using Game_Logic.Enums;

namespace Game_Logic.Contracts
{
    public interface IClientContract
    {
        FigureEnum GetUserInput(int dice, PlayerEnum playerID, List<FigureEnum> figureEnum);

        void HandleGameChanged(GameStatus gameStatus);
    }
}
