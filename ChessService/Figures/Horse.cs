using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public class Horse : Figure
    {
        private List<Point> moves = new List<Point> { new Point(1, 2), new Point(2, 1)};
        public Horse(int cI, int cJ, Image fig, int figValue) : base(cI, cJ, fig, figValue) { }

        public override List<Point> GetMoves()
        {
            acceptMoves = new List<Point>();
            int signX = -1, signY = -1;
            int curX, curY;
            for (int i = 0; i < 8; ++i)
            {
                if (i % 2 == 0)
                {
                    signX *= -1;
                    signY *= -1;
                }
                if (i % 4 == 0)
                    signX *= -1;

                (curX, curY) = (x + signX * moves[i % 2].X, y + signY * moves[i % 2].Y);
                if (Field.InsideField(curX, curY) && Field.AvaliableMove(curX, curY, owner))
                    acceptMoves.Add(new Point(curX, curY)); 
            }
            return acceptMoves;
        }
    }
}
