using ChessService;
using ChessService.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessServiceTests
{
    public class MoveTests
    {
        [Fact]
        public void MovesPawn() 
        {
            int x = 2, y = 1;
            int figValue = 16;
            Image figIm = Utils.CreateImage(figValue);
            List<Point> rightMoves = new List<Point>() { new Point(1, 2), new Point(1, 0)};
            var newPos = new int[8,8]
            {
            { 25,24,23,22,21,23,24,25 },
            { 26,26,26,26,26,26,26,26 },
            { 0,16,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0 },
            { 16,0,16,16,16,16,16,16 },
            { 15,14,13,12,11,13,14,15 },
            };
            Utils.CreatePosition(newPos);

            var pawn = new Pawn(x, y, figIm, figValue);  // пешка белых
            var resMoves = pawn.GetMoves();

            Assert.Equal(rightMoves.Count, resMoves.Count);
            if (rightMoves.Count == resMoves.Count)
            {
                foreach(var move in rightMoves)
                {
                    Assert.True(resMoves.Contains(move));
                }
            }
        }

        [Fact]
        public void MovesHorse()
        {
            int x = 5, y = 2;
            int figValue = 14;
            Image figIm = Utils.CreateImage(figValue);
            List<Point> rightMoves = new List<Point>() { new Point(3, 1), new Point(4, 4), new Point(3, 3),
                                                         new Point(4, 0), new Point(7, 1)};
            var newPos = new int[8, 8]
            {
            { 25,24,23,22,21,23,24,25 },
            { 26,26,26, 0,26,26,26,26 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0,26, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 14, 0, 0, 0, 0, 0 },
            { 16,16,16,16,16,16,16,16 },
            { 15, 0,13,12,11,13,14,15 }};
            Utils.CreatePosition(newPos);

            var horse = new Horse(x, y, figIm, figValue);  // конь белых
            var resMoves = horse.GetMoves();

            Assert.Equal(rightMoves.Count, resMoves.Count);
            if (rightMoves.Count == resMoves.Count)
            {
                foreach (var move in rightMoves)
                {
                    Assert.True(resMoves.Contains(move));
                }
            }
        }

        [Fact]
        public void MovesBishop()
        {
            int x = 4, y = 5;
            int figValue = 13;
            Image figIm = Utils.CreateImage(figValue);
            List<Point> rightMoves = new List<Point>() { new Point(7, 2), new Point(6, 3), new Point(5, 4), new Point(3, 6),
                                                         new Point(5, 6), new Point(3, 4), new Point(2, 3), new Point(1, 2)};
            var newPos = new int[8, 8]
            {
            { 25, 0,23,22,21,23,24,25 },
            { 26,26,26, 0,26,0,0,26 },
            { 24,0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0,26, 0, 26, 26, 0 },
            { 0, 0, 0, 0, 0, 13, 0, 0 },
            { 0, 0, 14,16,0, 0, 0, 0 },
            { 16,16,16,0,16,16,16,16 },
            { 15, 0,0,12,11,13,14,15 }};
            Utils.CreatePosition(newPos);

            var bishop = new Bishop(x, y, figIm, figValue);  // слон белых
            var resMoves = bishop.GetMoves();

            Assert.Equal(rightMoves.Count, resMoves.Count);
            if (rightMoves.Count == resMoves.Count)
            {
                foreach (var move in rightMoves)
                {
                    Assert.True(resMoves.Contains(move));
                }
            }
        }

        [Fact]
        public void MovesQueen()
        {
            int x = 5, y = 5;
            int figValue = 12;
            Image figIm = Utils.CreateImage(figValue);
            List<Point> rightMoves = new List<Point>() { new Point(7, 3), new Point(6, 4), new Point(4, 6), new Point(3, 7),
                                                         new Point(4, 4), new Point(5, 4), new Point(5, 3), new Point(5, 6),
                                                         new Point(5, 7)};
            var newPos = new int[8, 8]
            {
            { 25, 0,23,22,21,23,24,25 },
            { 26,26,26, 0,26, 0, 0,26 },
            {  0, 0, 0, 0, 0, 0, 0, 0 },
            {  0, 0, 0,26, 0, 0,26, 0 },
            {  0, 0, 0, 0,26,13, 0, 0 },
            {  0, 0,14,24, 0,12, 0, 0 },
            { 16,16,16, 0, 0,16,16,16 },
            { 15, 0, 0, 0,11,13,14,15 }};
            Utils.CreatePosition(newPos);

            var queen = new Queen(x, y, figIm, figValue);  // слон белых
            var resMoves = queen.GetMoves();

            Assert.Equal(rightMoves.Count, resMoves.Count);
            if (rightMoves.Count == resMoves.Count)
            {
                foreach (var move in rightMoves)
                {
                    Assert.True(resMoves.Contains(move));
                }
            }
        }

        [Fact]
        public void MovesRook()
        {
            int x = 4, y = 3;
            int figValue = 15;
            Image figIm = Utils.CreateImage(figValue);
            List<Point> rightMoves = new List<Point>() { new Point(4, 0), new Point(4, 1), new Point(4, 2), new Point(4, 4),
                                                         new Point(0, 3), new Point(1, 3), new Point(2, 3), new Point(3, 3)};
            var newPos = new int[8, 8]
            {
            { 25, 0,23,22, 0,23,24,25 },
            { 26,26,26, 0, 0, 21, 0, 0 },
            {  0, 0, 0, 0, 26, 0, 0, 0 },
            { 16, 0, 0, 0, 0, 0,26,26 },
            {  0, 0, 0,15,26,13, 0, 0 },
            {  0, 0,14,16, 0, 0, 0, 0 },
            {  0,16, 0, 0, 0,16,16,16 },
            {  0, 0, 0, 0,11,13,14,15 }};
            Utils.CreatePosition(newPos);

            var rook = new Rook(x, y, figIm, figValue);  // ладья белых
            var resMoves = rook.GetMoves();

            Assert.Equal(rightMoves.Count, resMoves.Count);
            if (rightMoves.Count == resMoves.Count)
            {
                foreach (var move in rightMoves)
                {
                    Assert.True(resMoves.Contains(move));
                }
            }
        }

        [Fact]
        public void MovesKing()
        {
            int x = 1, y = 5;
            int figValue = 21;
            Image figIm = Utils.CreateImage(figValue);
            List<Point> rightMoves = new List<Point>() { new Point(0, 4), new Point(1, 4), new Point(1, 6), new Point(2, 6),
                                                         new Point(2, 5)};
            var newPos = new int[8, 8]
            {
            { 25, 0,23,15, 0,23,24,25 },
            { 26,26,26, 0, 0, 21, 0, 0 },
            {  0, 0, 0, 0, 26, 0, 0, 0 },
            { 16, 0, 0, 0, 0, 0,26,26 },
            {  0, 0, 0, 0,26,13, 0, 0 },
            {  0, 0,14,16, 0, 0, 0, 0 },
            {  0,16, 0, 0, 0,16,16,16 },
            {  0, 0, 0, 11, 0,13,14,15 }};
            Utils.CreatePosition(newPos);

            var king = new King(x, y, figIm, figValue);  // король черных
            var resMoves = king.GetMoves();

            Assert.Equal(rightMoves.Count, resMoves.Count);
            if (rightMoves.Count == resMoves.Count)
            {
                foreach (var move in rightMoves)
                {
                    Assert.True(resMoves.Contains(move));
                }
            }
        }
    }
}
