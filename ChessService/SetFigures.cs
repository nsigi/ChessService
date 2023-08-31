using ChessService.Figures;
using ChessService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ChessService
{
    public class SetFigures 
    {
        public int side { get; set; }
        public  bool isCheck { get; set; }
        public  Point posKing { get; set; }
        private  HashSet<Figure> figures;
        //public  HashSet<Figure> lossFigures; // TODO для показа того, что съели
        public  HashSet<Point> acceptMoves;
        public  HashSet<Point> attackMoves;

        public SetFigures(int s, Point pos)
        {
            side = s;
            isCheck = false;
            posKing = pos;
            figures = new HashSet<Figure>();
            //lossFigures = new HashSet<Figure>();
            acceptMoves = new HashSet<Point>();
            attackMoves = new HashSet<Point>();
        }

        public SetFigures(){}

        public  void AddFigure(Figure f)
        {
            figures.Add(f);
        }

        public  void ChangePawn(Pawn prevPawn, Pawn curFig)
        {
            figures.Remove(prevPawn);
            figures.Add(curFig);
        }

        public void RemoveFigure(Figure f)
        {
            //lossFigures.Add(f);
            figures.Remove(f);
        }

        public  void UpdateAttackMoves()
        {
            CleanAttackMoves();
            foreach (var fig in figures)
            {
                foreach (var point in fig.GetAttackMoves())
                {
                    attackMoves.Add(point);
                }
            }
        }

        public  void CleanAttackMoves()
        {
            attackMoves.Clear();
        }

        public void UpdateAcceptMoves()
        {
            CleanAcceptMoves();
            //if (isCheck)
            //{
                foreach (var fig in figures)
                {
                    fig.acceptMoves = new HashSet<Point>();
                    var fromCell = new Point(fig.x, fig.y);
                    foreach (var toCell in fig.GetMoves())
                    {
                        var copyToFig = (Field.cells[toCell.X, toCell.Y].figure == null) ? null : Field.PlaceFigure(toCell.X, toCell.Y,
                            Field.cells[toCell.X, toCell.Y].figure.figureValue + 10 * Field.cells[toCell.X, toCell.Y].figure.owner);

                        Field.SymSwapCells(Field.cells[toCell.X, toCell.Y], Field.cells[fromCell.X, fromCell.Y]);

                        //Field.SetsFigures[side].isCheck = false;
                        Field.SetsFigures[GamePlay.GetOpponent(side)].UpdateAttackMoves();

                        if (!Utils.isSymCheck)
                        {
                            fig.acceptMoves.Add(toCell);
                            acceptMoves.Add(toCell);
                        }
                        else
                            Utils.isSymCheck = false;

                        Field.SymSwapCells(Field.cells[fromCell.X, fromCell.Y], Field.cells[toCell.X, toCell.Y]);

                        if (copyToFig != null)
                        {
                            Field.SetsFigures[GamePlay.GetOpponent(side)].AddFigure(copyToFig);
                            Field.cells[toCell.X, toCell.Y].figure = copyToFig;
                        }

                    }
                }
            //}
            //else
            //{
            //    foreach (var fig in figures)
            //    {
            //        acceptMoves = fig.acceptMoves = fig.GetMoves();
            //        //foreach (var point in fig.GetMoves())
            //        //{
            //        //    acceptMoves.Add(point);
            //        //}
            //    }
            //}
        }

        public void CleanAcceptMoves()
        {
            acceptMoves.Clear();
        }

        public void SetCheck()
        {
            Field.cells[posKing.X, posKing.Y].btn.BackColor = Color.Red;
            isCheck = true;
        }

        public void UnsetCheck()
        {
            isCheck = false;
            Field.cells[posKing.X, posKing.Y].btn.BackColor = Field.SetColorCell(posKing.X, posKing.Y);
        }
    }
}
