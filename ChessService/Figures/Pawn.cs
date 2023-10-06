using ChessService.HelpForms;
using ChessService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public class Pawn : Figure
    {
        public Pawn(int cI, int cJ, Image fig, int figValue, bool isnotMove = true) : base(cI, cJ, fig, figValue, isnotMove) { }

        public override HashSet<Point> GetMoves()
        {
            moves = new HashSet<Point>();
            int d = owner == 1 ? -1 : 1; // направление хода пешки
            if (Field.InsideField(x + 1 * d, y)) //прямо
            {
                if (Field.cells[x + 1 * d, y].figure == null)
                {
                    moves.Add(new Point(x + 1 * d, y));
                }
            }
            if (owner == (int)Side.White  && x == 6 || owner == (int)Side.Black && x == 1) // на 2 клетки
            {
                if (Field.InsideField(x + 1 * d, y))
                {
                    if (Field.cells[x + 1 * d, y].figure == null)
                    {
                        if (Field.InsideField(x + 2 * d, y))
                        {
                            if (Field.cells[x + 2 * d, y].figure == null)
                            {
                                moves.Add(new Point(x + 2 * d, y));
                            }
                        }
                    }
                }
            }

            TakeFigure(x + d, y + 1); // справа
            TakeFigure(x + d, y - 1); //слева

            return moves;
        }

        public override HashSet<Point> GetAttackMoves()
        {
            attackMoves = new HashSet<Point>();
            int cx = x + ((owner == 1) ? -1 : 1); // направление хода пешки

            if (Field.InsideField(cx, y + 1))
                CheckAttackEndMoves(cx, y + 1);
                //attackMoves.Add(new Point());
            if (Field.InsideField(cx, y - 1))
                CheckAttackEndMoves(cx, y - 1);
            //attackMoves.Add(new Point(cx, y - 1));

            return attackMoves;
        }

        public void TakeFigure(int cx, int cy)
        {
            if (Field.InsideField(cx, cy) && Field.cells[cx, cy].figure != null && Field.cells[cx, cy].figure.owner != owner)
                if (Field.cells[cx, cy].figure != null && Field.cells[cx, cy].figure.IsKing())
                    Utils.isSymCheck = true;
                else
                    moves.Add(new Point(cx, cy));
        }
    }
}
