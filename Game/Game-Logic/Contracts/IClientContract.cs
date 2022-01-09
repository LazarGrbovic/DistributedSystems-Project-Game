using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Packets;

namespace Game_Logic.Contracts
{
    public interface IClientContract
    {
        int RequestFigureID(int playerID, List<int> figureIDs);

        void HandleGameStatusUpdate(GameStatus gameStatus);
    }
}
