using ChessService.Figures;
using ChessService.HelpForms;
using ChessService.Types;
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
        public static List<SetFigures> SetsFigures; // 1 - WhiteSetFigures, 2 - BlackSetFigures;

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
            SetsFigures = new List<SetFigures>();
            SetsFigures.Add(null);
            SetsFigures.Add(new SetFigures((int)Side.White, new Point(7, 4)));
            SetsFigures.Add(new SetFigures((int)Side.Black, new Point(0, 4)));
            Field.cells = new Cell[8, 8];
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    int figValue = (Field.field[i, j] / 10 == 1) ? 1 : (Field.field[i, j] / 10 == 0) ? 0 : 2;
                    var btn = CreateButton(i, j);

                    Figure fig = PlaceFigure(i, j, Field.field[i, j]);
                    if (fig != null)
                    {
                        btn.BackgroundImage = fig.figureIm;
                        SetsFigures[Field.field[i, j] / 10].AddFigure(fig);
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
            SetsFigures[(int)Side.White].UpdateAcceptMoves();
            SetsFigures[(int)Side.Black].UpdateAcceptMoves();
        }

        public static Button CreateButton(int i, int j)
        {
            Button btn = new Button();
            btn.Padding = new Padding(1, 0, 0, 0);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = SetColorCell(i, j);
            btn.Size = new Size(100, 100);
            btn.Location = new Point(75 + j* 100, 25 + i* 100);
            btn.ForeColor = Color.FromArgb(100, 111, 64);
            return btn;
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

            if (prevCell != null) //unset color select
                prevCell.btn.BackColor = SetColorCell(prevCell.pos.X, prevCell.pos.Y);

            if (curCell.figure != null && Field.cells[i, j].figure.owner == curPlayer)
            {
                HideMoves();
                HashSet<Point> acceptMoves = curCell.figure.acceptMoves;
                //var allAcceptMoves = SetsFigures[curPlayer].acceptMoves;//искать пересечение доступных и допустимых
                //foreach (var move in curCell.figure.GetMoves())
                //{
                //    if(allAcceptMoves.Contains(move))
                //        acceptMoves.Add(move);//TODO можно ли так делать
                //}
                curBtn.BackColor = Color.FromArgb(100, 111, 64); // выделение текущей фигуры
                          
                LockCells();
                ShowMoves(acceptMoves);
                
                if (isMoving)
                {
                    HideMoves();
                    if (!SetsFigures[curPlayer].isCheck)
                        curBtn.BackColor = SetColorCell(i, j);
                    else
                        Field.cells[SetsFigures[curPlayer].posKing.X, SetsFigures[curPlayer].posKing.Y].btn.BackColor = Color.Red;
                    //LockCells();
                    EnableCells();
                }
                else
                {
                    EnableCells(acceptMoves);
                }
                isMoving = !isMoving;
                prevCell = curCell;
            }
            else
            {
                if (isMoving)
                {
                    SwapCells(curCell, prevCell);

                    AnalysPosition(curCell.pos, curPlayer);

                    isMoving = false;
                    HideMoves();
                    //LockCells();
                    EnableCells();
                    curPlayer = Utils.GetOpponent(curPlayer); // смена хода
                    prevCell = null;
                    //if (curCell.figure.x == 1)
                    //    MessageBox.Show("Мат");
                }
            }
        }

        public static void AnalysPosition(Point move, int side)
        {
            SetsFigures[side].UpdateAttackMoves();

            if (SetsFigures[side].isCheck && SetsFigures[side].acceptMoves.Contains(move)) //если сделан допустимый ход
                SetsFigures[side].UnsetCheck();
            if (SetsFigures[side].attackMoves.Contains(SetsFigures[Utils.GetOpponent(side)].posKing))
                Utils.SetCheckOpponent(side);

            SetsFigures[Utils.GetOpponent(side)].UpdateAcceptMoves();

            if (SetsFigures[Utils.GetOpponent(side)].isCheck)
            {
                if (SetsFigures[Utils.GetOpponent(side)].acceptMoves.Count == 0)
                    MessageBox.Show("Мат");
            }
            else
            {
                if (SetsFigures[Utils.GetOpponent(side)].acceptMoves.Count == 0)
                    MessageBox.Show("Пат");
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
            if (cur.figure != null)
            {
                SetsFigures[Utils.GetOpponent(curPlayer)].RemoveFigure(cur.figure);
            }
            if (prev.figure.figureValue == 6 && (cur.pos.X == 0 || cur.pos.X == 7))// пешка дошла до края
            {
                Field.SetsFigures[curPlayer].RemoveFigure(prev.figure);
                var pickForm = new ChangePawnForm(curPlayer, cur.pos);
                pickForm.Show();
            }
            else
            {
                Field.cells[cur.pos.X, cur.pos.Y].figure = Field.cells[prev.pos.X, prev.pos.Y].figure;
                prev.figure.Move(cur.pos);
                cur.btn.BackgroundImage = prev.btn.BackgroundImage;
            }
            prev.btn.BackgroundImage = null;
            prev.figure = null;
            // удаление фигуры, если там она была (в список удаленных)
        }

        public static void SymSwapCells(Cell cur, Cell prev)
        {
            if (cur.figure != null)
            {
                SetsFigures[cur.figure.owner].RemoveFigure(cur.figure);
            }
            Field.cells[cur.pos.X, cur.pos.Y].figure = Field.cells[prev.pos.X, prev.pos.Y].figure;
            prev.figure.Move(cur.pos);
            prev.figure = null;
            //SwapCells(cur, prev);
            //cur.figure = prev.figure;
            //prev.figure = bufFig;
        }

        public static Figure DefFigure(Point newPos, Cell c)
        {
            int figValue = c.figure.owner * 10 + c.figure.figureValue;
            switch (c.figure.figureValue)
            {
                case 1: return new King(newPos.X, newPos.Y, c.figure.figureIm, figValue);
                case 2: return new Queen(newPos.X, newPos.Y, c.figure.figureIm, figValue);
                case 3: return new Bishop(newPos.X, newPos.Y, c.figure.figureIm, figValue);
                case 4: return new Horse(newPos.X, newPos.Y, c.figure.figureIm, figValue);
                case 5: return new Rook(newPos.X, newPos.Y, c.figure.figureIm, figValue);
                case 6: return new Pawn(newPos.X, newPos.Y, c.figure.figureIm, figValue);
                default:
                    return null;
            }
        }

        public static bool AvaliableMove(int x, int y, int owner)
        {
            return Field.cells[x, y].figure == null || Field.cells[x, y].figure.owner != owner && !Field.cells[x, y].figure.IsKing();
        }

        public static bool IsNotEmptyCell(int x, int y, int owner)
        {
            return Field.cells[x, y].figure != null;
        }

        public static void ShowMoves(HashSet<Point> moves)
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
                    if (Field.cells[i, j].figure != null)
                        Field.cells[i, j].btn.Enabled = true;
                }
            }
        }

        public static void EnableCells(HashSet<Point> moves)
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
