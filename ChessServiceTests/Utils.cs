using ChessService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessServiceTests
{
    public static class Utils
    {
        public static Image CreateImage(int figValue)
        {
            Image figure = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(figure);
            g.DrawImage(new Bitmap("C:\\Users\\_Asus_\\Documents\\Study\\ChessService\\Spites\\chess.png"), new Rectangle(0, 0, 100, 100), 150 * (figValue % 10 - 1),
                            (figValue / 10 != 1) ? 150 : 0, 150, 150, GraphicsUnit.Pixel);
            return figure;
        }

        public static void CreatePosition(int[,] newField)
        {
            Field.field = newField;
        }

    }
}
