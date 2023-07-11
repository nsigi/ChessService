using ChessService.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService
{
    public static class Field
    {
        public static int[,] field { get; set; }
        public static Cell[,] cells { get; set; }
        private static Cell prevCell { get; set; }
        public static int curPlayer; // 1 - белые, 2 - черные
        public static bool isMoving = false;
        public static FieldUI FieldUI { get; set; }

        public static void Init(FieldUI field)
        {
            FieldUI = field;
            Field.field = new int[8, 8]
            {
            { 25,24,23,22,21,23,24,25 },
            { 26,26,26,26,26,26,26,26 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 16,16,16,16,16,16,16,16 },
            { 15,14,13,12,11,13,14,15 }};

            curPlayer = 1;
            CreateField();
        }

        public static void CreateField()
        {
            Field.cells = new Cell[8, 8];
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    int figValue = (Field.field[i, j] / 10 == 1) ? 1 : (Field.field[i, j] / 10 == 0) ? 0 : 2;
                    Button btn = new Button();
                    btn.Padding = new Padding(1, 0, 0, 0);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = SetColorCell(i, j);
                    btn.Size = new Size(100, 100);
                    btn.Location = new Point(75 + j * 100, 25 + i * 100);
                    //cell.Text = "⚫";
                    btn.ForeColor = Color.FromArgb(100, 111, 64);

                    Figure fig = PlaceFigure(i, j, Field.field[i, j]);
                    if (fig != null)
                    {
                        btn.BackgroundImage = fig.figureIm;
                    }
                    else
                    {
                        btn.Enabled = false;
                    }
                    btn.Click += new EventHandler(OnClick);
                    FieldUI.Controls.Add(btn);

                    Field.cells[i, j] = new Cell(new Point(i, j), btn, fig);
                }
            }
        }

        public static Figure PlaceFigure(int x, int y, int figValue)
        {
            SpritesFigures.SpriteFigures();
            Image figure = (figValue / 10 == 1) ? SpritesFigures.WhiteFigursImages[figValue % 10] : SpritesFigures.BlackFigursImages[figValue % 10];

            switch (figValue % 10)
            {
                case 1: return new King(x, y, figure, figValue);
                case 2: return new Queen(x, y, figure, figValue);
                case 3: return new Bishop(x, y, figure, figValue);
                case 4: return new Horse(x, y, figure, figValue);
                case 5: return new Rook(x, y, figure, figValue);
                case 6: return new Pawn(x, y, figure, figValue);
                default:
                    return null;
            }
        }

        public static void OnClick(object sender, EventArgs e)
        {
            Button curBtn = sender as Button;
            Cell curCell = null;
            int i = 0, j = 0;
            foreach (Cell c in Field.cells)
            {
                if (c.btn == curBtn)
                {
                    curCell = c;
                    i = c.pos.X;
                    j = c.pos.Y;
                    break;
                }
            }

            if (prevCell != null)
                prevCell.btn.BackColor = SetColorCell(prevCell.pos.X, prevCell.pos.Y);

            if (curCell.figure != null && Field.field[i, j] / 10 == curPlayer)
            {
                HideMoves();
                curBtn.BackColor = Color.FromArgb(100, 111, 64); // выделение текущей фигуры
                LockCells();
                List<Point> possMoves = curCell.figure.GetMoves();
                ShowMoves(possMoves);

                if (isMoving)
                {
                    HideMoves();
                    curBtn.BackColor = SetColorCell(i, j);
                    EnableCells();
                    isMoving = false;
                }
                else
                {
                    isMoving = true;
                    EnableCells(possMoves);
                }
                prevCell = curCell;
            }
            else
            {
                if (isMoving)
                {
                    Field.SwapCells(curCell, prevCell);
                    isMoving = false;
                    HideMoves();
                    EnableCells();
                    curPlayer = curPlayer % 2 + 1; // смена хода
                    prevCell = null;
                }
            }
        }

        public static Color SetColorCell(int i, int j)
        {
            return ((i + j) % 2 != 0) ? Color.FromArgb(181, 136, 99) : Color.FromArgb(240, 217, 181);
        }

        public static bool InsideField(int i, int j)
        {
            return i < 8 && j < 8 && i > -1 && j > -1;
        }

        public static void SwapCells(Cell cur, Cell prev)
        {
            (Field.field[cur.pos.X, cur.pos.Y], Field.field[prev.pos.X, prev.pos.Y]) = (Field.field[prev.pos.X, prev.pos.Y], 0);
            cur.btn.Text = null;
            if (cur.figure == null)
                cur.figure = DefFigure(new Point(cur.pos.X, cur.pos.Y), prev);
            else
            {
                cur.figure = prev.figure;
                prev.figure.Move(new Point(cur.pos.X, cur.pos.Y));
            }
            cur.btn.BackgroundImage = prev.btn.BackgroundImage;
            prev.btn.BackgroundImage = null;
            // удаление фигуры, если там она была (в список удаленных)
        }

        public static Figure DefFigure(Point newPos, Cell c)
        {
            switch (c.figure.figureValue)
            {
                case 1: return new King(newPos.X, newPos.Y, c.figure.figureIm, Field.field[newPos.X, newPos.Y]);
                case 2: return new Queen(newPos.X, newPos.Y, c.figure.figureIm, Field.field[newPos.X, newPos.Y]);
                case 3: return new Bishop(newPos.X, newPos.Y, c.figure.figureIm, Field.field[newPos.X, newPos.Y]);
                case 4: return new Horse(newPos.X, newPos.Y, c.figure.figureIm, Field.field[newPos.X, newPos.Y]);
                case 5: return new Rook(newPos.X, newPos.Y, c.figure.figureIm, Field.field[newPos.X, newPos.Y]);
                case 6: return new Pawn(newPos.X, newPos.Y, c.figure.figureIm, Field.field[newPos.X, newPos.Y]);
                default:
                    return null;
            }
        }

        public static bool AvaliableMove(int x, int y, int owner)
        {
            return Field.field[x, y] == 0 || Field.field[x, y] / 10 != owner;

        }

        public static bool CheckCell(int x, int y, int owner)
        {
            return Field.field[x, y] != 0;

        }

        public static void ShowMoves(List<Point> moves)
        {
            if (moves == null) return;
            foreach (Point p in moves)
            {
                Field.cells[p.X, p.Y].btn.Text = "⚫";
            }
        }

        public static void HideMoves()
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Field.cells[i, j].btn.Text = null;
                }
            }
        }

        public static void EnableCells()
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Field.cells[i, j].btn.Enabled = true;
                }
            }
        }

        public static void EnableCells(List<Point> moves)
        {
            if (moves == null) return;
            foreach (Point p in moves)
            {
                Field.cells[p.X, p.Y].btn.Enabled = true;
            }
        }

        public static void LockCells()
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (Field.cells[i, j].figure == null || Field.cells[i, j].figure.owner != curPlayer)
                        Field.cells[i, j].btn.Enabled = false;
                }
            }
        }
    }
}
