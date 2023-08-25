using ChessService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService
{
    public static class Movement
    {
        public static DataGridView MoveList { get; set; }
        private static List<string> SituationSymbol = new List<string>() { "", "+", "#"};
        public static int CountMoves;
        private static int CharNumberA = 97;
        public static string [,] SignCells { get; set; }

        public static void Init(DataGridView table)
        {
            MoveList = table;
            MoveList.ClearSelection();
            CountMoves = 0;
        }

        public static string ConvertCoords(Point coords)
        {
            return (char)(CharNumberA + coords.Y) + (8 - coords.X).ToString();
        }
        public static string GenMoveText(Cell cellMove, bool isBeat, int situation)
        {
            return SpritesFigures.FiguresSymbols[cellMove.figure.figureValue] + (isBeat ? "x" : "") +
                ConvertCoords(cellMove.pos) + SituationSymbol[situation];
        }
        public static void WriteMove(Cell cellMove, bool isBeat, int situation) // 0 - free, 1 - check, 2 - checkmate 
        {
            var moveText = GenMoveText(cellMove, isBeat, situation);
            if(cellMove.figure.owner == (int)Side.White)
            {
                MoveList.Rows.Add();
                MoveList[0, CountMoves].Value = (CountMoves + 1).ToString();
                MoveList[1, CountMoves].Value = moveText;
            }
            else
            {
                MoveList[2, CountMoves].Value = moveText;
                ++CountMoves;
            }         
        }
    }
}
