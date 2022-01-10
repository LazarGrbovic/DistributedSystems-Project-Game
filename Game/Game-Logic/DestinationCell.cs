using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Enums;

namespace Game_Logic
{
    public class DestinationCell
    {
        private PlayerEnum player;

        public DestinationCell(PlayerEnum player, int entryPos)
        {
            this.EntryPos = entryPos;
            this.player = player;
            this.Position_1 = FigureEnum.NoFigure;
            this.Position_2 = FigureEnum.NoFigure;
            this.Position_3 = FigureEnum.NoFigure;
            this.Position_4 = FigureEnum.NoFigure;
        }

        public int EntryPos { get; private set; }
        public FigureEnum Position_1 { get; private set; }
        public FigureEnum Position_2 { get; private set; }
        public FigureEnum Position_3 { get; private set; }
        public FigureEnum Position_4 { get; private set; }

        public void SetPosition(int pos, FigureEnum figure, PlayerEnum player)
        {
            if (this.player != player) { throw new Exception("Player Does Match With The Destination House"); }
            
            switch (pos)
            {
                case 1:
                    this.Position_1 = figure;
                    break;
                case 2:
                    this.Position_2 = figure;
                    break;
                case 3:
                    this.Position_3 = figure;
                    break;
                case 4:
                    this.Position_4 = figure;
                    break;
                default:
                    throw new Exception("Invalid Figure Enum");
            }
        }

        public void RemovePlayer(int pos, FigureEnum figure, PlayerEnum player)
        {
            switch (pos)
            {
                case 1:
                    this.Position_1 = FigureEnum.NoFigure;
                    break;
                case 2:
                    this.Position_2 = FigureEnum.NoFigure;
                    break;
                case 3:
                    this.Position_3 = FigureEnum.NoFigure;
                    break;
                case 4:
                    this.Position_4 = FigureEnum.NoFigure;
                    break;
                default:
                    throw new Exception("Invalid Figure Enum");
            }
        }
    }
}
