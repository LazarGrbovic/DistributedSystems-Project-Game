using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Managers;
using Game_Logic.Packets;
using Game_Logic.Contracts;

namespace Game_Logic
{
    public class Game
    {
        private GameManager gameManager;
        private List<EnhancedPlayer> enhancedPlayers;
        private EnhancedPlayer activeEnhancedPlayer;
        public EventHandler<GameStatus> OnChangedGameStatus;
        private IClientContract clientContract;

        public Game(IClientContract clientContract)
        {
            this.clientContract = clientContract;
            this.enhancedPlayers = new List<EnhancedPlayer>();
            this.gameManager = new GameManager();
            this.gameManager.OnGameStatusChanged += this.HandleChangedGameStatus;
        }

        public void StartGame()
        {
            //this.OnChangedGameStatus.Invoke(this, new GameStatus(new List<GameboardCell>().ToArray(), new List<Player>().ToArray()));
            for (int i = 1; i < 5; i++)
            { this.enhancedPlayers.Add(new EnhancedPlayer(new Player(i), this.clientContract)); }
            gameManager.PrepareGame(this.enhancedPlayers);

            this.gameManager.HandleGame(this.enhancedPlayers);
        }        

        private void PollCurrentPlayer_GetFigureID()
        {
        }

        private void SetNewActiveClient()
        {
            if (this.enhancedPlayers[3] == this.activeEnhancedPlayer) { this.activeEnhancedPlayer = this.enhancedPlayers[0]; return; }

            var index = 1 + this.enhancedPlayers.IndexOf(this.activeEnhancedPlayer);
            this.activeEnhancedPlayer = this.enhancedPlayers[index++];
        }

        private void HandleChangedGameStatus(object sender, GameStatus gameStatus)
        {
            this.clientContract.HandleGameStatusUpdate(gameStatus);
        }
    }
}
