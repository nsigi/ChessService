using ChessService.Timers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessService
{
    public partial class GameUI : Form
    {
        public GameUI()
        {
            InitializeComponent();
            Init();
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            Clear();
            Init();
        }

        private void Clear()
        {
            FieldPanel.Controls.Clear();
            MovesTable.Rows.Clear();
            MovesTable.Refresh();
            GameTimers.Stop();
            GamePlay.ClearLabelsInfo();
        }
        private void Init()
        {
            Field.Init(FieldPanel);
            Movement.Init(MovesTable);
            GameTimers.Init(new TimeSpan(0, 5, 5), labelWhiteTimer, timerWhite, labelBlackTimer, timerBlack);
            GamePlay.Init(labelInfoWhite, labelInfoBlack);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameTimers.Start();
            Field.EnableCells();
        }
    }
}
