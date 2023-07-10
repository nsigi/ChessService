using ChessService;
using ChessService.Figures;
using System.Drawing;
using System.Net.NetworkInformation;

namespace ChessServiceTests
{
    public class CreateFieldTests
    {
        [Fact]
        public void CheckCreatePawn()
        {
            int x = 6, y = 0;
            int figValue = 16;
            Image figIm = Utils.CreateImage(figValue);
            
            var pawn = new Pawn(x, y, figIm, figValue);  // пешка белых

            Assert.NotNull(pawn); //проверка на создание
            Assert.Equal(x, pawn.x); //проверка на соответсвие координат по горзонтали
            Assert.Equal(y, pawn.y); //проверка на соответсвие координат по вертикали
            Assert.Equal(figIm, pawn.figureIm); //проверка на соответсвие изображения
        }

        [Fact]
        public void CheckCreateBishop()
        {
            int x = 7, y = 2;
            int figValue = 13;
            Image figIm = Utils.CreateImage(figValue);

            var bishop = new Pawn(x, y, figIm, figValue);  // пешка белых

            Assert.NotNull(bishop); //проверка на создание
            Assert.Equal(x, bishop.x); //проверка на соответсвие координат по горзонтали
            Assert.Equal(y, bishop.y); //проверка на соответсвие координат по вертикали
            Assert.Equal(figIm, bishop.figureIm); //проверка на соответсвие изображения
        }

        [Fact]
        public void CheckBackColorCell()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(5, 4);
            Color c1 = Color.FromArgb(240, 217, 181);
            Color c2 = Color.FromArgb(181, 136, 99);

            Color color1 = Field.SetColorCell(p1.X, p1.Y);
            Color color2 = Field.SetColorCell(p2.X, p2.Y);
            
            Assert.Equal(c1, color1);
            Assert.Equal(c2, color2);
        }

        [Fact]
        public void CheckInsudeField() 
        {
            Point p1 = new Point(1, 0);
            Point p2 = new Point(5, 4);
            Point p3 = new Point(7, 9);

            bool resp1 = Field.InsideField(p1.X, p1.Y);
            bool resp2 = Field.InsideField(p2.X, p2.Y);
            bool resp3 = Field.InsideField(p3.X, p3.Y);

            Assert.True(resp1);
            Assert.True(resp2);
            Assert.False(resp3);
        }
    }
}