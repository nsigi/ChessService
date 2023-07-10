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
        public bool onBoard = true;

        public List<Point> acceptMoves;
        
        public Figure() { }
        public Figure(int cX, int cY, Image figIm, int figValue)
        {
            x = cX;
            y = cY;
            figureIm = figIm;
            owner = figValue / 10;
            figureValue = figValue % 10;
        }

        public abstract List<Point> GetMoves();       
    
        public void Eat(Figure figOp)
        {
            figureValue = figOp.figureValue;
            (x, y) = (figOp.x, figOp.y);
            figOp.onBoard = false;
        }
    }
}
