using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Enums;

namespace Game_Logic
{
    public class Cell
    {
        public int ID { get; private set; }
        public PlayerEnum Player { get; private set; }
        public FigureEnum Figure { get; private set; }
        public Cell(int ID)
        {
            this.Player = PlayerEnum.NoPlayer;
            this.Figure = FigureEnum.NoFigure;
            this.ID = ID;
        }

        public void SetPlayerAndFigure(PlayerEnum player, FigureEnum figure)
        {
            this.Player = player;
            this.Figure = figure;
        }

        public void RemovePlayer()
        {
            this.Player = PlayerEnum.NoPlayer;
            this.Figure = FigureEnum.NoFigure;
        }
    }
}
