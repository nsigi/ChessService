using ChessService.Types;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Timers
{
    public class GameTimer
    {
        public TimeSpan Time { get; set; }
        public Label ViewLabel { get; set; }
        public System.Windows.Forms.Timer PlayTimer { get; set; }
        private int Side { get; set; }
        
        public GameTimer(TimeSpan time, Label lab, System.Windows.Forms.Timer timer, int side)
        {
            Side = side;
            Time = time;
            ViewLabel = lab;
            ViewLabel.Text = Time.ToString();
            PlayTimer = timer;
            PlayTimer.Tick += new EventHandler(UpdateTime);
            PlayTimer.Tick += new EventHandler(CheckZero);
        }

        public void UpdateTime(object sender, EventArgs e)
        {
            Time -= new TimeSpan(0, 0, 1);
            ViewLabel.Text = Time.ToString();
        }

        public void CheckZero(object sender, EventArgs e)
        {
            TimeSpan ZeroTime = new TimeSpan(0, 0, 0);
            if (Time == ZeroTime)
            {
                GamePlay.EndGame((int)Situation.OutOfTime);
            }

        }
    }
}
