namespace ChessService
{
    partial class GameUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameUI));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            FieldPanel=new Panel();
            RestartBtn=new Button();
            labelMoves=new Label();
            MovesTable=new DataGridView();
            Number=new DataGridViewTextBoxColumn();
            MovesWhite=new DataGridViewTextBoxColumn();
            MovesBlack=new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)MovesTable).BeginInit();
            SuspendLayout();
            // 
            // FieldPanel
            // 
            FieldPanel.Location=new Point(300, 75);
            FieldPanel.Name="FieldPanel";
            FieldPanel.Size=new Size(800, 800);
            FieldPanel.TabIndex=0;
            // 
            // RestartBtn
            // 
            RestartBtn.BackColor=SystemColors.MenuHighlight;
            RestartBtn.BackgroundImage=(Image)resources.GetObject("RestartBtn.BackgroundImage");
            RestartBtn.Font=new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            RestartBtn.ForeColor=Color.White;
            RestartBtn.Location=new Point(48, 75);
            RestartBtn.Name="RestartBtn";
            RestartBtn.Size=new Size(204, 87);
            RestartBtn.TabIndex=1;
            RestartBtn.Text="Restart";
            RestartBtn.UseVisualStyleBackColor=false;
            RestartBtn.Click+=RestartBtn_Click;
            // 
            // labelMoves
            // 
            labelMoves.AutoSize=true;
            labelMoves.Font=new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            labelMoves.Location=new Point(1178, 75);
            labelMoves.Name="labelMoves";
            labelMoves.Size=new Size(131, 41);
            labelMoves.TabIndex=3;
            labelMoves.Text="Moves";
            // 
            // MovesTable
            // 
            MovesTable.AllowUserToAddRows=false;
            MovesTable.AllowUserToDeleteRows=false;
            MovesTable.AllowUserToResizeColumns=false;
            MovesTable.AllowUserToResizeRows=false;
            MovesTable.BackgroundColor=Color.Snow;
            MovesTable.CellBorderStyle=DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment=DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor=Color.SeaGreen;
            dataGridViewCellStyle1.Font=new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor=SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor=SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor=SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode=DataGridViewTriState.True;
            MovesTable.ColumnHeadersDefaultCellStyle=dataGridViewCellStyle1;
            MovesTable.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MovesTable.Columns.AddRange(new DataGridViewColumn[] { Number, MovesWhite, MovesBlack });
            dataGridViewCellStyle4.Alignment=DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor=SystemColors.Window;
            dataGridViewCellStyle4.Font=new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor=SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor=SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor=SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode=DataGridViewTriState.False;
            MovesTable.DefaultCellStyle=dataGridViewCellStyle4;
            MovesTable.Location=new Point(1178, 119);
            MovesTable.Name="MovesTable";
            MovesTable.ReadOnly=true;
            MovesTable.RowHeadersBorderStyle=DataGridViewHeaderBorderStyle.None;
            MovesTable.RowHeadersVisible=false;
            MovesTable.RowHeadersWidth=62;
            MovesTable.RowTemplate.Height=33;
            MovesTable.Size=new Size(354, 756);
            MovesTable.TabIndex=4;
            // 
            // Number
            // 
            dataGridViewCellStyle2.BackColor=Color.LightGray;
            Number.DefaultCellStyle=dataGridViewCellStyle2;
            Number.HeaderText="№";
            Number.MinimumWidth=8;
            Number.Name="Number";
            Number.ReadOnly=true;
            Number.Resizable=DataGridViewTriState.False;
            Number.SortMode=DataGridViewColumnSortMode.NotSortable;
            Number.Width=50;
            // 
            // MovesWhite
            // 
            MovesWhite.HeaderText="";
            MovesWhite.MinimumWidth=8;
            MovesWhite.Name="MovesWhite";
            MovesWhite.ReadOnly=true;
            MovesWhite.Resizable=DataGridViewTriState.False;
            MovesWhite.SortMode=DataGridViewColumnSortMode.NotSortable;
            MovesWhite.Width=150;
            // 
            // MovesBlack
            // 
            dataGridViewCellStyle3.BackColor=Color.White;
            MovesBlack.DefaultCellStyle=dataGridViewCellStyle3;
            MovesBlack.HeaderText="";
            MovesBlack.MinimumWidth=8;
            MovesBlack.Name="MovesBlack";
            MovesBlack.ReadOnly=true;
            MovesBlack.Resizable=DataGridViewTriState.False;
            MovesBlack.SortMode=DataGridViewColumnSortMode.NotSortable;
            MovesBlack.Width=150;
            // 
            // GameUI
            // 
            AutoScaleDimensions=new SizeF(10F, 25F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1578, 944);
            Controls.Add(MovesTable);
            Controls.Add(labelMoves);
            Controls.Add(RestartBtn);
            Controls.Add(FieldPanel);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="GameUI";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Chess";
            ((System.ComponentModel.ISupportInitialize)MovesTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel FieldPanel;
        private Button RestartBtn;
        private Label labelMoves;
        private DataGridView MovesTable;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn MovesWhite;
        private DataGridViewTextBoxColumn MovesBlack;
    }
}