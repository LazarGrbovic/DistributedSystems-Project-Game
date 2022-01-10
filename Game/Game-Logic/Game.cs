using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Contracts;

namespace Game_Logic
{
    public class Game
    {
        private IClientContract clientContract;
        public Game(IClientContract clientContract)
        {
            this.clientContract = clientContract;
        }

        public void StartGame()
        {
            var gameManager = new GameManager(this.clientContract);
            gameManager.StartGame();
        }
    }
}
