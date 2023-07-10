using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public class Bishop : Figure
    {
        public Bishop(int cI, int cJ, Image fig, int figValue) : base(cI, cJ, fig, figValue) { }
        public override List<Point> GetMoves()
        {
            acceptMoves = new List<Point>();

            int j = y + 1;
            for (int i = x - 1; i > -1; --i, ++j) // ю-в
                if (CheckEndMoves(i, j)) break;

            j = y - 1;
            for (int i = x - 1; i > -1; --i, --j) // ю-з
                if (CheckEndMoves(i, j)) break;

            j = y - 1;
            for (int i = x + 1; i < 8; ++i, --j) // с-з
                if (CheckEndMoves(i, j)) break;

            j = y + 1;
            for (int i = x + 1; i < 8; ++i, ++j) //с-в
                if (CheckEndMoves(i, j)) break;

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
