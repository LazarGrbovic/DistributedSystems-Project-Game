using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic.Enums;

namespace Game_Logic
{
    public class Player
    {
        public PlayerEnum ID { get; private set; }
        public List<FigureEnum> ActiveFigures { get; private set; }
        public List<FigureEnum> FiguresAtDestination { get; private set; }
        public List<FigureEnum> FiguresAtStart { get; private set; }

        public Player(PlayerEnum id)
        {
            this.ID = id;
            this.ActiveFigures = new List<FigureEnum>();
            this.FiguresAtStart = new List<FigureEnum>() { FigureEnum.Figure_1, FigureEnum.Figure_2, FigureEnum.Figure_3, FigureEnum.Figure_4 };
            this.FiguresAtDestination = new List<FigureEnum>();
        }

        public void DecreaseFiguresAtStart(FigureEnum figure)
        {
            this.FiguresAtStart.Remove(figure);
            this.ActiveFigures.Add(figure);
        }

        public void DecreaseActiveFiguresAndIncreaseStartFigures(FigureEnum figure)
        {
            this.ActiveFigures.Remove(figure);
            this.FiguresAtStart.Add(figure);
        }

        public void DecreaseActiveFiguresAndIncreaseFiguresAtDestination(FigureEnum figure)
        {
            this.ActiveFigures.Remove(figure);
            this.FiguresAtDestination.Add(figure);
        }
    }
}
