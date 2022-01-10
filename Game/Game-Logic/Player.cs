using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Player
    {
        public int ID { get; private set; }
        public int CountOfActiveFigures { get; private set; }   
        public int CountOfFiguresAtStartHouse  { get; set; }
        public int CountOfFiguresAtDestination { get; set; }

        public List<int> FiguresAtStartHouse { get; set; }
        public List<int> ActiveFiguresIDs { get; set; }

        public Player(int id)
        {
            this.FiguresAtStartHouse = new List<int> {1, 2, 3 ,4};
            this.ID = id;
            this.CountOfActiveFigures = 0;
            this.CountOfFiguresAtStartHouse = 4;
            this.CountOfFiguresAtDestination = 0;
            this.ActiveFiguresIDs = new List<int>();
        }

        public void IncreaseActiveFigures(int figureID)
        {
            this.CountOfActiveFigures++;
            this.ActiveFiguresIDs.Add(figureID);
            this.CountOfFiguresAtStartHouse--;
            this.FiguresAtStartHouse.Remove(figureID);
        }

        public void IncreaseFiguresAtDestination()
        {
            this.CountOfFiguresAtDestination++;
            this.CountOfActiveFigures--;
        }

        public void SetFigureAtStartHouse(int figureID)
        {
            this.CountOfActiveFigures--;
            this.FiguresAtStartHouse.Add(figureID);
            this.ActiveFiguresIDs.Remove(figureID);
        }
    }
}
