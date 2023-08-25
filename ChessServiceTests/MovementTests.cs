using ChessService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessServiceTests
{
    public class MovementTests
    {
        [Fact]
        public void ConvertCoords()
        {
            var coords = new Point[4] { new Point(0, 0), new Point(4, 4), new Point (7, 5), new Point(1, 3) };
            var rightConverts = new string[] { "a8", "e4", "f1", "d7"};
            var resConverts = new string[4];

            for (int i = 0; i < 4; ++i)
                resConverts[i] = Movement.ConvertCoords(coords[i]);

            for (int i = 0; i < 4; ++i)
                Assert.Equal(rightConverts[i], resConverts[i]);
        }

        [Fact]
        public void WriteMove()
        {

        }
    }
}
