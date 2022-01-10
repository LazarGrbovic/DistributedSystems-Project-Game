using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Packets;
using Game_Logic;
using Game_Logic.Contracts;
using Game_Logic.Enums;

namespace Game_Console
{
    #region Game Board Field With Numbered Fields
    /*

    B B             19      20      21<   C C
    B B             18      C1      22    C C 
                    17      C2      23
    V               16      C3      24
    11  12  13  14  15      C4      25  26  27  28  29
    10  B1  B2  B3  B4              D4  D3  D2  D1  30
    09  08  07  06  05      A4      35  34  33  32  31
                    04      A3      36               ^
                    03      A2      37              
                    02      A1      38            D  D
      A A         > 01      00      39            D  D
      A A           
    */
    #endregion

    public class GameRunner : IClientContract
    {
        private Renderer _renderer;
        public void RunGame()
        {
            Console.WriteLine("Welcome to the \"Mensch ärgere dich nicht! / Man don't get angry game!\"");

            var game = new Game(this);
            this._renderer = new Renderer();            

            //game.OnChangedGameStatus += this.HandleOnChangedGameStatus;            
            game.StartGame();
            Console.ReadLine();
        }

        public void HandleGameChanged(GameStatus gameStatus)
        {
            this._renderer.RenderGameboard(gameStatus);
        }

        public FigureEnum GetUserInput(int dice, PlayerEnum playerID, List<FigureEnum> figureIDs)
        {
            return this._renderer.GetUserInput(dice, playerID, figureIDs);
        }

        
        /*
        
        GameRunner

        public void RunGame()
        { 
            Console.WriteLine("Welcome to the \"Mensch ärgere dich nicht! / Man don't get angry game!\"");
            
            var game = new Game();
            var renderer = new Renderer();
            
            this.gameboardCellVMs = new GameboardCellVM[40];
            for (int i = 0; i < 40; i++)
            {
                gameboardCellVMs[i] = new GameboardCellVM(i);
            }

            renderer.RenderGameboard();
            //game.OnChangedGameStatus += this.HandleOnChangedGameStatus;            
            //game.StartGame();
            Console.ReadLine();
        }

        private GameboardCellVM[] gameboardCellVMs;

        private void HandleOnChangedGameStatus(object sender, GameStatus gameStatus)
        {
            Console.WriteLine("Game sent this");
        }

        private GameStatus CreateGameStatusForTesting()
        {
            throw new NotImplementedException();
        }
        
        */
    }
}
