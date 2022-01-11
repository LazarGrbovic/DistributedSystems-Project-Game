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

        public static DestinationCellFigureHoldersEnum IntToDestinationEnum(int id)
        {
            switch (id)
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
                    throw new Exception("Invalid Destination Figure Holder Number");
            }
        }

        public static DestinationCellFigureHoldersEnum GetPlaceInTheDestination(PlayerEnum player, int pos, int dice, DestinationCell[] destinationCells)
        {
            for (int i = 1; i <= dice; i++)
                {
                var nextPos = CalculateNewPos(pos, i);
                if (IsNextPosADestinationEntrance(player, nextPos, destinationCells)) 
                {
                    return IntToDestinationEnum(dice - i); 
                }
            }

            throw new Exception("Invalid Place In The Destination House");
        }

        public static DestinationCell GetDestinationCellByPlayer(Player player, DestinationCell[] destinationCells)
        {
            foreach (var destinationCell in destinationCells)
            {
                if (destinationCell.Player == player.ID) { return destinationCell; }
            }

            throw new Exception("Invalid Destination Cell");
        }

        public static bool CheckIfPlayerWillEnterDestination(PlayerEnum player, int pos, int dice, DestinationCell[] destinationCells)
        {
            var res = false;
            for (int i = 1; i <= dice; i++)
            {
                var nextPos = CalculateNewPos(pos, i);
                if (IsNextPosADestinationEntrance(player, nextPos, destinationCells) && i < dice) {  return true; }
            }

            return false;
        }

        public static bool IsNextPosADestinationEntrance(PlayerEnum player, int pos, DestinationCell[] destinationCells)
        {
            foreach (var destinationCell in destinationCells) { if (destinationCell.EntryPos == pos && destinationCell.Player == player) { return true; } }

            return false;
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
