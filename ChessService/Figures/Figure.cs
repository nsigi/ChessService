using ChessService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public abstract class Figure
    {
        public int x { get; set; }
        public int y { get; set; }
        public Image figureIm { get; set;}
        public int owner { get; set;}
        public int figureValue { get; set;}
        public bool isNotMove { get; set;}

        public HashSet<Point> acceptMoves;
        public HashSet<Point> moves;
        public HashSet<Point> attackMoves;
        
        public Figure() { }
        public Figure(int cX, int cY, Image figIm, int figValue, bool isnotMove = true)
        {
            x = cX;
            y = cY;
            figureIm = figIm;
            owner = figValue / 10;
            figureValue = figValue % 10;
            isNotMove = isnotMove;
        }

        public abstract HashSet<Point> GetMoves();
        public abstract HashSet<Point> GetAttackMoves();
        public virtual bool CheckEndMoves(int cx, int cy)
        {
            if (Field.InsideField(cx, cy) && Field.AvaliableMove(cx, cy, owner))
                moves.Add(new Point(cx, cy));
            return Field.InsideField(cx, cy) && Field.IsNotEmptyCell(cx, cy);
        }

        public virtual bool CheckAttackEndMoves(int cx, int cy)
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

            return Field.InsideField(cx, cy) && Field.IsNotEmptyCell(cx, cy);
        }


        public void Eat(Figure figOp)
        {
            if (figOp.figureValue != (int)FigureType.King)
            {
                figureValue = figOp.figureValue;
                Move(new Point(figOp.x, figOp.y));
            }
        }

        public virtual void Move(Point point)
        {
            (x, y) = (point.X, point.Y);
        }
    
        public bool IsKing()
        {
            return (figureValue == (int)FigureType.King);
        }

        public bool IsRook()
        {
            return (figureValue == (int)FigureType.Rook);
        }
    }
}
