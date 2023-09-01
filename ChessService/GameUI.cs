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
        private int StartButtonCounter { get; set; }
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
            labelWhiteTimer.BackColor = labelBlackTimer.BackColor = Color.Snow;
            GameTimers.Init(new TimeSpan(0, 5, 5), labelWhiteTimer, timerWhite, labelBlackTimer, timerBlack);
            GamePlay.Init(labelInfoWhite, labelInfoBlack);
            StartButton.Text = "Start";
            StartButtonCounter = 0;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (GamePlay.IsNotEndGame)
            {
                switch (StartButtonCounter)
                {
                    case 0:
                        {
                            StartGame();
                            ++StartButtonCounter;
                            break;
                        }
                    case 1:
                        {
                            StartButton.Text = "Play";
                            GameTimers.Stop();
                            Field.LockAllCells();
                            ++StartButtonCounter;
                            break;
                        }
                    case 2:
                        {
                            StartGame();
                            --StartButtonCounter;
                            break;
                        }
                }
            }
        }
        public void DisableStartButton()
        {
            StartButton.Enabled = false;
        }
        private void StartGame()
        {
            StartButton.Text = "Pause";
            GameTimers.Start();
            Field.EnableCells();
        }
    }
}
