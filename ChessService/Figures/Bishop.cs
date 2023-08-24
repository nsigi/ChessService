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
        public override HashSet<Point> GetMoves()
        {
            moves = new HashSet<Point>();

            int j = y + 1;
            for (int i = x - 1; i > -1; --i, ++j) // с-в
                if (CheckEndMoves(i, j)) break;

            j = y - 1;
            for (int i = x - 1; i > -1; --i, --j) // с-з
                if (CheckEndMoves(i, j)) break;

            j = y - 1;
            for (int i = x + 1; i < 8; ++i, --j) // ю-з
                if (CheckEndMoves(i, j)) break;

            j = y + 1;
            for (int i = x + 1; i < 8; ++i, ++j) // ю-в
                if (CheckEndMoves(i, j)) break;

            return moves;
        }

        public override HashSet<Point> GetAttackMoves()
        {
            attackMoves = new HashSet<Point>();
            int j = y + 1;
            for (int i = x - 1; i > -1; --i, ++j) // ю-в
                if (CheckAttackEndMoves(i, j)) break;

            j = y - 1;
            for (int i = x - 1; i > -1; --i, --j) // ю-з
                if (CheckAttackEndMoves(i, j)) break;

            j = y - 1;
            for (int i = x + 1; i < 8; ++i, --j) // с-з
                if (CheckAttackEndMoves(i, j)) break;

            j = y + 1;
            for (int i = x + 1; i < 8; ++i, ++j) //с-в
                if (CheckAttackEndMoves(i, j)) break;

            return attackMoves;
        }

    }
}
