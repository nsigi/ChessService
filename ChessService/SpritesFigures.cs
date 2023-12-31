﻿using ChessService.Figures;
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
        public static List<Image> WhiteFiguresImages = new List<Image>(7);
        public static List<Image> BlackFiguresImages = new List<Image>(7);
        public static List<string> FiguresSymbols = new List<string>() {"", "♔", "♕", "♗", "♘", "♖", "♙" };

        public static void SpriteFigures()
        {
            WhiteFiguresImages.Add(null);
            BlackFiguresImages.Add(null); // для удобной индексации

            for (int i = 0; i < 12; ++i)
            {
                var figIm = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(figIm);
                var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\ChessService\\Resources\\chess.png");
                //g.DrawImage(new Bitmap("C:\\Users\\_Asus_\\Documents\\Laboratory\\ChessService\\ChessService\\Images\\chess.png"),
                g.DrawImage(new Bitmap(path),
                    new Rectangle(0, 0, 100, 100), 150 * (i / 2), (i % 2 == 1) ? 0 : 150, 150, 150, GraphicsUnit.Pixel);

                if (i % 2 == 1)
                    WhiteFiguresImages.Add(figIm);
                else
                    BlackFiguresImages.Add(figIm);
            }
        }
    }
}
