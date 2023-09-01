using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public class Horse : Figure
    {
        private List<Point> dirs = new List<Point> { new Point(1, 2), new Point(2, 1)};
        public Horse(int cI, int cJ, Image fig, int figValue, bool isnotMove = true) : base(cI, cJ, fig, figValue, isnotMove) { }

        public override HashSet<Point> GetMoves()
        {
            moves = new HashSet<Point>();
            int signX = -1, signY = -1;
            int cx, cy;
            for (int i = 0; i < 8; ++i)
            {
                if (i % 2 == 0)
                {
                    signX *= -1;
                    signY *= -1;
                }
                if (i % 4 == 0)
                    signX *= -1;

                (cx, cy) = (x + signX * dirs[i % 2].X, y + signY * dirs[i % 2].Y);
                CheckEndMoves(cx, cy);                 
            }
            return moves;
        }

        public override bool CheckEndMoves(int cx, int cy)
        {
            if (Field.InsideField(cx, cy) && Field.AvaliableMove(cx, cy, owner))
            {
                moves.Add(new Point(cx, cy));
                return true;
            }
            return false;
        }

        public override HashSet<Point> GetAttackMoves()
        {
            attackMoves = new HashSet<Point>();
            int signX = -1, signY = -1;
            int cx, cy;
            for (int i = 0; i < 8; ++i)
            {
                if (i % 2 == 0)
                {
                    signX *= -1;
                    signY *= -1;
                }
                if (i % 4 == 0)
                    signX *= -1;

                (cx, cy) = (x + signX * dirs[i % 2].X, y + signY * dirs[i % 2].Y);
                CheckAttackEndMoves(cx, cy);
            }
            return attackMoves;
        }

        public override bool CheckAttackEndMoves(int cx, int cy)
        {
            if (Field.InsideField(cx, cy))
            {
                attackMoves.Add(new Point(cx, cy));
                if (Field.cells[cx, cy].figure != null && Field.cells[cx, cy].figure.owner != owner &&
                    Field.cells[cx, cy].figure.IsKing()) //встречен ли на пути вражеский король
                {
                    Utils.isSymCheck = true;
                    return true;
                }
            }

            return Field.InsideField(cx, cy);
        }
    }
}
