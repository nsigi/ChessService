using ChessService.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService
{
    public static class SpritesFigures
    {
        // 1 - king, 2 - queen, 3 - bishop, 4 - horse, 5 - rook, 6 - pawn
        public static List<Image> WhiteFigursImages = new List<Image>(7);
        public static List<Image> BlackFigursImages = new List<Image>(7);
        public static void SpriteFigures()
        {
            WhiteFigursImages.Add(null);
            BlackFigursImages.Add(null); // для удобной индексации

            for (int i = 0; i < 12; ++i)
            {
                var figIm = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(figIm);
                g.DrawImage(new Bitmap("C:\\Users\\_Asus_\\Documents\\Laboratory\\ChessService\\ChessService\\Images\\chess.png"),
                    new Rectangle(0, 0, 100, 100), 150 * (i / 2), (i % 2 == 1) ? 0 : 150, 150, 150, GraphicsUnit.Pixel);

                if (i % 2 == 1)
                    WhiteFigursImages.Add(figIm);
                else
                    BlackFigursImages.Add(figIm);
            }
        }
    }
}
