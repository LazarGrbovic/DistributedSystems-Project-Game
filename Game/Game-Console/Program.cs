using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic;
using Game_Logic.Packets;

namespace Game_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 40;

            var gameRunner = new GameRunner();
            gameRunner.RunGame();
        }
    }
}
