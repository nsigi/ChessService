using ChessService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Timers
{
    public static class GameTimers
    {
        //public static TimeSpan StartTime { get; set; }
        // 0 - null, 1 - white, 2 - black
        private static List<GameTimer> Timers = new List<GameTimer>();
        //public static GameTimer WhiteTimer { get; set; }
        //public static GameTimer BlackTimer { get; set; }

        public static void Init(TimeSpan startTime, Label whiteLabel, System.Windows.Forms.Timer whiteTimer,
            Label blackLabel, System.Windows.Forms.Timer blackTimer)
        {
            Timers.Add(null);
            Timers.Add(new GameTimer(startTime, whiteLabel, whiteTimer, (int)Side.White));
            Timers.Add(new GameTimer(startTime, blackLabel, blackTimer, (int)Side.Black));
        }

        public static void Start()
        {
            Timers[GamePlay.CurrentPlayer].PlayTimer.Start();
            Timers[GamePlay.GetOpponent()].ViewLabel.BackColor = Utils.BlackoutColor;
            Timers[GamePlay.CurrentPlayer].ViewLabel.BackColor = Color.Snow;
        }
        public static void ChangeCourse()
        {
            Timers[GamePlay.GetOpponent()].PlayTimer.Stop();
            Start();

        }

        public static void Stop() {
            for (int i = 1; i < 3; ++i)
            {
                Timers[i].PlayTimer.Stop();
                Timers[i].ViewLabel.BackColor = Color.FromArgb((int)(255 * 0.6), Color.Black);
            }
        }
    }
}
