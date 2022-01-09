using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Packets;

namespace Game_Logic.Managers
{
    public class GameManager
    {
        #region 
        private Gameboard gameboard;        
        private List<EnhancedPlayer> enhancedPlayers;
        private bool finishedGame;
        private EnhancedPlayer activeEnhancedPlayer;
        private Random random;     
        
        public EventHandler<GameStatus> OnGameStatusChanged;
        #endregion
        public void HandleGame(List<EnhancedPlayer> enhancedPlayers)
        {
            this.enhancedPlayers = enhancedPlayers;
            this.activeEnhancedPlayer = this.enhancedPlayers[0];
            
            while (!this.finishedGame)
            {                
                if (this.activeEnhancedPlayer.Player.CountOfActiveFigures == 0) { this.HandlePlayerWithNoActiveFigures (this.activeEnhancedPlayer); }
                else { this.HandleMove(this.activeEnhancedPlayer); }

                this.SetNewActivePlayer();
                var players = new List<Player>();
                foreach (var player in this.enhancedPlayers)
                {
                    players.Add(player.Player);
                }
                var gameStatus = new GameStatus(this.gameboard.Cells, players.ToArray());
                this.FireOnGameStatusChanged(gameStatus);    
            }
        }
      
        public void PrepareGame(List<EnhancedPlayer> enhancedPlayers)
        {
            this.random = new Random();
            this.finishedGame = false;
            this.gameboard = new Gameboard();
            this.enhancedPlayers = enhancedPlayers;
            var players = new List<Player>();
            foreach (var player in this.enhancedPlayers)
            {
                players.Add(player.Player);
            }
            var gameStatus = new GameStatus(this.gameboard.Cells, players.ToArray());

            this.FireOnGameStatusChanged(gameStatus);
        }

        private void HandleMove(EnhancedPlayer enhancedPlayer)
        {
            var activeFiguresIDs = enhancedPlayer.Player.ActiveFiguresIDs;
            var figureID = enhancedPlayer.RequestMoveFigureID(activeFiguresIDs);
            
            var cell = this.gameboard.GetCellByFigureFromPlayer(figureID, enhancedPlayer.Player.ID);
            
            if (cell.HasPlayer()) { this.ModifyTakenGameCell(cell, enhancedPlayer.Player, figureID ); }
            else { cell.SetPlayerAndFigure(enhancedPlayer.Player, figureID); }
        }

        private void HandlePlayerWithNoActiveFigures(EnhancedPlayer enhancedPlayer)
        {
            for (int i = 0; i < 3; i++)
            {
                int diceNumber = this.RollDice();
                if (diceNumber == 6)
                { 
                    int figureID = enhancedPlayer.RequestMoveFigureID(new List<int>{1,2,3,4});
                    // TODO ValidateFigureID
                    
                    int pos = this.gameboard.GetStartingPositionOfPlayer(enhancedPlayer.Player.ID);
                    this.ModifyGameboardFigures(enhancedPlayer.Player, figureID, pos);                    
                    enhancedPlayer.Player.IncreaseActiveFigures(figureID);

                    break;
                }
            }

            // FireEvent
        }

        private void ModifyGameboardFigures(Player newPlayer, int newFigureID, int pos)
        {
            var cell = this.gameboard.GetCellByID(pos); 

            if (this.gameboard.Cells[pos].HasPlayer()) 
            {this.ModifyTakenGameCell(cell, newPlayer, newFigureID); return; }
            
            this.ModifyEmptyGameCell(newPlayer, newFigureID, pos);
        }

        private void ModifyEmptyGameCell(Player newPlayer, int newFigureID, int pos)
        {
            this.gameboard.Cells[pos].SetPlayerAndFigure(newPlayer, newFigureID);
        }

        private void ModifyTakenGameCell(GameboardCell cell, Player newPlayer, int newFigureID)
        {
            int pos = cell.CellID;
            Player oldPlayer = cell.Player;
            int oldFigureID = cell.FigureID;

            oldPlayer.SetFigureAtStartHouse(oldFigureID);
            this.gameboard.Cells[pos].SetPlayerAndFigure(newPlayer, newFigureID);
        }


        private int RollDice() { return this.random.Next(1,7); }

        private void SetNewActivePlayer()
        {
            if (this.activeEnhancedPlayer == this.enhancedPlayers[3]) {this.activeEnhancedPlayer = this.enhancedPlayers[0]; return; }

            this.activeEnhancedPlayer = this.enhancedPlayers[1 + this.enhancedPlayers.IndexOf(this.activeEnhancedPlayer)]; 
        }

        private void FireOnGameStatusChanged(GameStatus gameStatus)
        {
            this.OnGameStatusChanged.Invoke(this, gameStatus);
        }
    }
}
