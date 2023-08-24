using ChessService.Types;
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
        public override HashSet<Point> GetMoves()
        {
            moves = new HashSet<Point>();
           
            CheckEndMoves(x + 1, y); //вверх
            CheckEndMoves(x - 1, y); //вниз
            CheckEndMoves(x, y + 1); //вправо
            CheckEndMoves(x, y - 1); //влево

            CheckEndMoves(x + 1, y + 1); // с-в
            CheckEndMoves(x - 1, y + 1); // ю-в
            CheckEndMoves(x - 1, y - 1); // ю-з
            CheckEndMoves(x + 1, y - 1); // с-з

            return moves;
        }

        public override void Move(Point point)
        {
            base.Move(point);
            Field.SetsFigures[owner].posKing = point;
        }

        public override HashSet<Point> GetAttackMoves()
        {
            attackMoves = new HashSet<Point>();

            CheckAttackEndMoves(x + 1, y); // вниз
            CheckAttackEndMoves(x - 1, y); // вверх
            CheckAttackEndMoves(x, y + 1); // вправо
            CheckAttackEndMoves(x, y - 1); // влево

            CheckAttackEndMoves(x + 1, y + 1); // ю-в
            CheckAttackEndMoves(x - 1, y + 1); // с-в
            CheckAttackEndMoves(x - 1, y - 1); // с-з
            CheckAttackEndMoves(x + 1, y - 1); // ю-з

            return attackMoves;
        }

        public override bool CheckAttackEndMoves(int cx, int cy)//TODO дописать точнее, чтобы короли не пересекались
        {
            if (Field.InsideField(cx, cy))
            {
                if (Field.cells[cx, cy].figure != null && Field.cells[cx, cy].figure.owner != owner &&
                    Field.cells[cx, cy].figure.IsKing()) //встречен ли на пути вражеский король
                    return true;
                attackMoves.Add(new Point(cx, cy));
            }

            return Field.InsideField(cx, cy) && Field.AvaliableMove(cx, cy, owner);
        }

        //TODO проверка полей на шах
        // проверка на рокировку
    }
}
