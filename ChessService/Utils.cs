using ChessService;
using ChessService.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService
{
    public static class Utils
    {
        public static bool isSymCheck = false;
        public static void HelpSpritesFigures()
        {
            SpritesFigures.SpriteFigures();
        }

        public static Image GetImage(int figValue)
        {
            return (figValue / 10 == 1) ? SpritesFigures.WhiteFigursImages[figValue % 10] : SpritesFigures.BlackFigursImages[figValue % 10];
        }

        public static void CreatePosition(int[,] newField)
        {
            Field.field = newField;
        }

        public static int GetOpponent(int owner) //TODO перенести
        {
            return (owner % 2 + 1);
        }

        public static void SetCheckOpponent(int side) //TODO перенести
        {
            Field.SetsFigures[GetOpponent(side)].SetCheck();
        }
    }
}
