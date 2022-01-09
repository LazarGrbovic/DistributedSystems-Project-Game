using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Contracts;
using Game_Logic.Packets;

namespace Game_Console
{
    public class ConsoleContract : IClientContract
    {
        public void HandleGameStatusUpdate(GameStatus gameStatus)
        {
            // Render Game
            throw new NotImplementedException();
        }

        public int RequestFigureID(int playerID, List<int> figureIDs)
        {
            return 2;
        }
    }
}
