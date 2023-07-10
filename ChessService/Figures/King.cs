using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public class King : Figure
    {
        public King(int cI, int cJ, Image fig, int figValue) : base(cI, cJ, fig, figValue) { }
        public override List<Point> GetMoves()
        {
            acceptMoves = new List<Point>();
           
            CheckEndMoves(x + 1, y); //вверх
            CheckEndMoves(x - 1, y); //вниз
            CheckEndMoves(x, y + 1); //вправо
            CheckEndMoves(x, y - 1); //влево

            CheckEndMoves(x + 1, y + 1); // с-в
            CheckEndMoves(x - 1, y + 1); // ю-в
            CheckEndMoves(x - 1, y - 1); // ю-з
            CheckEndMoves(x + 1, y - 1); // с-з

            return acceptMoves;
        }

        public void CheckEndMoves(int cx, int cy)
        {
            if (Field.InsideField(cx, cy) && Field.AvaliableMove(cx, cy, owner))
                acceptMoves.Add(new Point(cx, cy));
        }

        //проверка полей на шах
        // проверка на рокировку
    }
}
