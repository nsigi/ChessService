using ChessService.Timers;
using ChessService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService
{
    public static class GamePlay
    {
        // 0 - победила команда, которая вызвала метод той или иной, 1 - ничья, 2 - пат, 3 - время
        public static int CurrentPlayer; // 1 - белые, 2 - черные
        private static List<Label> LabelsInfo = new List<Label>();
        public static bool IsNotEndGame { get; set; }
        
        public static void Init(Label infoWhite, Label infoBlack)
        {
            LabelsInfo.Add(null);
            LabelsInfo.Add(infoWhite);
            LabelsInfo.Add(infoBlack);
            IsNotEndGame = true;
        }

        public static int GetOpponent() 
        {
            return (CurrentPlayer % 2 + 1);
        }

        public static int GetOpponent(int side)
        {
            return (side % 2 + 1);
        }

        public static void ChangeSide()
        {
            CurrentPlayer = CurrentPlayer % 2 + 1;
        }

        public static void SetCheckOpponent(int side) 
        {
            Field.SetsFigures[GetOpponent(side)].SetCheck();
        }

        public static void EndGame(int situation) 
        {
            GameTimers.Stop();
            EndInfo(situation);
            IsNotEndGame = false;
            //MessageBox.Show(GetReason(situation));
        }

        private static string GetReason(int situation)
        {
            switch (situation)
            {
                case (int)Situation.Checkmate:
                    return "Объявлен мат";
                case (int)Situation.Pat:
                    return "Пат";
                case (int)Situation.Draw:
                    return "Ничья";
                case (int)Situation.OutOfTime:
                    return "Время вышло";
                default:
                    return "";
            }
        }

        private static void EndInfo(int situation)
        {
            switch(situation)
            {
                case (int)Situation.Checkmate:
                    WriteWinInfo();
                    break;
                case (int)Situation.Pat:
                    WriteEqualEndMessage("Pat");
                    break;
                case (int)Situation.Draw:
                    WriteEqualEndMessage("Draw");
                    break;
                case (int)Situation.OutOfTime:
                    {
                        ChangeSide();
                        WriteWinInfo();
                    }
                    break;
            }
        }

        private static void WriteWinInfo()
        {
            LabelsInfo[CurrentPlayer].ForeColor = Color.FromArgb(86, 153, 80);
            LabelsInfo[CurrentPlayer].Text = "Win";
            LabelsInfo[GetOpponent()].ForeColor = Color.FromArgb(204, 51, 51);
            LabelsInfo[GetOpponent()].Text = "Defeat";
        }

        private static void WriteEqualEndMessage(string info)
        {
            for (int i = 1; i < 3; ++i)
            {
                LabelsInfo[i].ForeColor = Color.FromArgb(64, 64, 64);
                LabelsInfo[i].Text = info;
            }
        }

        public static void ClearLabelsInfo()
        {
            for (int i = 1; i < 3; ++i)
                LabelsInfo[i].Text = "";
        }
    }
}
