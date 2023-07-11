using ChessService.HelpForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Figures
{
    public class Pawn : Figure
    {
        public Pawn(int cI, int cJ, Image fig, int figValue) : base(cI, cJ, fig, figValue) { }

        public override List<Point> GetMoves()
        {
            acceptMoves = new List<Point>();
            int d = owner == 1 ? -1 : 1; // направление хода пешки
            if (Field.InsideField(x + 1 * d, y)) //прямо
            {
                if (Field.field[x + 1 * d, y] == 0)
                {
                    acceptMoves.Add(new Point(x + 1 * d, y));
                }
            }
            if (owner == 1 && x == 6 || owner == 2 && x == 1) // на 2 клетки
            {
                if (Field.InsideField(x + 1 * d, y))
                {
                    if (Field.field[x + 1 * d, y] == 0)
                    {
                        if (Field.InsideField(x + 2 * d, y))
                        {
                            if (Field.field[x + 2 * d, y] == 0)
                            {
                                acceptMoves.Add(new Point(x + 2 * d, y));
                            }
                        }
                    }
                }
            }

            TakeFigure(x + 1 * d, y + 1); // справа
            TakeFigure(x + 1 * d, y - 1); //слева

            return acceptMoves;
        }
    
        public void TakeFigure(int cx, int cy)
        {
            if (Field.InsideField(cx, cy) && Field.field[cx, cy] != 0 && Field.field[cx, cy] / 10 != owner)
                acceptMoves.Add(new Point(cx, cy));
        }

        public override void Move(Point point) 
        {
            (x, y) = (point.X, point.Y);
            if (x == 0 || x == 7)
            {
                var pickForm = new ChangePawnForm(owner, new Point(x, y));
                pickForm.Show();
                //figureIm = Utils.GetImage(owner * 10 + figureValue);
                //figureValue = Field.field[x, y] % 10;
                //Field.cells[x, y].btn.BackgroundImage = figureIm;
            }
        }
        //public ChangeFigure() { }
    }
}
