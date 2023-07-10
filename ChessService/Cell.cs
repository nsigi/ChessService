using ChessService.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService
{
    public class Cell
    {
        public Point pos;
        public Button btn { get; set; }
        public Figure figure { get; set; }
        public Cell(Point position, Button button, Figure fig) 
        {
            pos = new Point(position.X, position.Y);
            btn = button;
            figure = fig;
        }

    }
}
