using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Enums;

namespace Game_Logic.Utilities
{
    public static class GameManagerUtility
    {
        public static int GetDestinationEntryOfPlayer(PlayerEnum player, Gameboard gameboard)
        {
            switch (player)
            {
                case PlayerEnum.Player_1:
                    return gameboard.Player_1_DestinationEntry;
                case PlayerEnum.Player_2:
                    return gameboard.Player_2_DestinationEntry;
                case PlayerEnum.Player_3:
                    return gameboard.Player_3_DestinationEntry;
                case PlayerEnum.Player_4:
                    return gameboard.Player_4_DestinationEntry;
                case PlayerEnum.NoPlayer:
                    throw new Exception("Invalid PlayerEnum");
                default:
                    throw new Exception("Invalid PlayerEnum");
            }
        }

        public static Player GetPlayerByPlayerEnum(PlayerEnum playerID, Player[] players)
        {
            foreach (var player in players)
            {
                if (player.ID == playerID)
                {
                    return player;
                }
            }

            throw new Exception("Invalid Player ID");
        }
        public static int CalculateNewPos(int oldPos, int newPos)
        {
            if (oldPos + newPos > 39) { return (oldPos + newPos) - 40; }
            return oldPos + newPos;
        }
    }
}
