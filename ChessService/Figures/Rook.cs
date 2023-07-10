using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public class Rook : Figure
    {
        public Rook(int cI, int cJ, Image fig, int figValue) : base(cI, cJ, fig, figValue) { }
        public override List<Point> GetMoves()
        {
            acceptMoves = new List<Point>();
            for (int i = x + 1; i < 8; ++i) //вверх
                if (CheckEndMoves(i, y)) break;
            for (int i = x - 1; i > -1; --i) //вниз
                if (CheckEndMoves(i, y)) break;
            for (int j = y + 1; j < 8; ++j) //вправо
                if (CheckEndMoves(x, j)) break;
            for (int j = y - 1; j > -1; --j) //влево
                if (CheckEndMoves(x, j)) break;

            return acceptMoves;
        }

        public bool CheckEndMoves(int cx, int cy)
        {
            if (Field.InsideField(cx, cy) && Field.AvaliableMove(cx, cy, owner))
                acceptMoves.Add(new Point(cx, cy));
            return Field.InsideField(cx, cy) && Field.CheckCell(cx, cy, owner);
        }
    }
}
