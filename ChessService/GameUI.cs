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
        }
        private void Init()
        {
            Field.Init(FieldPanel);
            Movement.Init(MovesTable);
        }
    }
}
