using ChessService.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessService.HelpForms
{
    public partial class ChangePawnForm : Form
    {
        //TODO форма появляется там, где пешка
        private Point figurePosition;
        private int side;
        public bool isBeat { set; private get; }
        public ChangePawnForm(int owner, Point position, bool beat)
        {
            InitializeComponent();
            SpritesFigures.SpriteFigures();
            figurePosition = position;
            side = owner;
            isBeat = beat;
            Init();
        }

        public void Init()
        {
            //this.Location = startPosition;
            this.BackColor = Color.FromArgb(240, 217, 181);
            for (int i = 2; i < 6; ++i)
            {
                Button btn = new Button();
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Size = new Size(100, 100);
                btn.Location = new Point(50, (i - 2) * 100);
                btn.TabIndex = i;
                btn.BackgroundImage = Utils.GetImage(side * 10 + i);
                btn.Click += new EventHandler(OnClick);
                this.Controls.Add(btn);
            }
        }

        public void OnClick(object sender, EventArgs e)
        {
            int newFigValue = side * 10 + (sender as Button).TabIndex;
            //Field.field[figurePosition.X, figurePosition.Y] = newFigValue;
            Figure newFigure = ChangePawn(figurePosition.X, figurePosition.Y, Utils.GetImage(newFigValue), newFigValue);
            // TODO сделать замену в соответствующем наборе
            Field.cells[figurePosition.X, figurePosition.Y].figure = newFigure;
            Field.cells[figurePosition.X, figurePosition.Y].btn.BackgroundImage = newFigure.figureIm;
            Field.SetsFigures[side].AddFigure(newFigure);
            int sit = Field.AnalysPosition(figurePosition, side);
            var moveText = SpritesFigures.FiguresSymbols[6] + (isBeat ? "x" : "") + Movement.ConvertCoords(figurePosition) +
                "=" + SpritesFigures.FiguresSymbols[newFigValue % 10] + Movement.SituationSymbol[sit];
            Movement.WriteMove(moveText, side);
            this.Close();
        }

        public Figure ChangePawn(int x, int y, Image figIM, int figValue)
        {
            switch (figValue % 10)
            {
                case 2: return new Queen(x, y, figIM, figValue);
                case 3: return new Bishop(x, y, figIM, figValue);
                case 4: return new Horse(x, y, figIM, figValue);
                case 5: return new Rook(x, y, figIM, figValue);
                default:
                    return null;
            }
        }
    }
}
