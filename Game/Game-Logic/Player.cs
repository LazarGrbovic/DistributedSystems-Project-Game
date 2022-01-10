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

        public Player(int id)
        {
            this.SetPlayerEnumID(id);
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

        private void SetPlayerEnumID(int id)
        {
            switch (id)
            {
                case 1:
                    this.ID = PlayerEnum.Player_1; 
                    break;
                case 2:
                    this.ID = PlayerEnum.Player_2;
                    break;
                case 3:
                    this.ID = PlayerEnum.Player_3;
                    break;
                case 4:
                    this.ID = PlayerEnum.Player_4;
                    break;
                default:
                    throw new Exception("Invalid ID");
            }
        }
    }
}
