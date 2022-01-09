using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Contracts;

namespace Game_Logic
{
    public class EnhancedPlayer
    {
        private IClientContract _clientContract;
        public Player Player { get; private set; }
        public EnhancedPlayer(Player player, IClientContract client)
        {
            this.Player = player;
            this._clientContract = client;
        }
        public int RequestMoveFigureID(List<int> possibleFiguresIDs)
        {
            return this._clientContract.RequestFigureID(this.Player.ID, possibleFiguresIDs);
        }
    }
}
