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
        public override HashSet<Point> GetMoves()
        {
            moves = new HashSet<Point>();
            for (int i = x + 1; i < 8; ++i) //вниз
                if (CheckEndMoves(i, y)) break;
            for (int i = x - 1; i > -1; --i) // вверх
                if (CheckEndMoves(i, y)) break;
            for (int j = y + 1; j < 8; ++j) //вправо
                if (CheckEndMoves(x, j)) break;
            for (int j = y - 1; j > -1; --j) //влево
                if (CheckEndMoves(x, j)) break;

            return moves;
        }

        public override HashSet<Point> GetAttackMoves()
        {
            attackMoves = new HashSet<Point>();

            for (int i = x + 1; i < 8; ++i) // вниз
                if (CheckAttackEndMoves(i, y)) break;
            for (int i = x - 1; i > -1; --i) // вверх
                if (CheckAttackEndMoves(i, y)) break;
            for (int j = y + 1; j < 8; ++j) // вправо
                if (CheckAttackEndMoves(x, j)) break;
            for (int j = y - 1; j > -1; --j) //влево
                if (CheckAttackEndMoves(x, j)) break;

            return attackMoves;
        }
    }
}
