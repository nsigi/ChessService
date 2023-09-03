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
            components=new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameUI));
            FieldPanel=new Panel();
            RestartBtn=new Button();
            labelMoves=new Label();
            MovesTable=new DataGridView();
            Number=new DataGridViewTextBoxColumn();
            MovesWhite=new DataGridViewTextBoxColumn();
            MovesBlack=new DataGridViewTextBoxColumn();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            label6=new Label();
            label7=new Label();
            label8=new Label();
            label9=new Label();
            label10=new Label();
            label11=new Label();
            label12=new Label();
            label13=new Label();
            label14=new Label();
            label15=new Label();
            label16=new Label();
            timerWhite=new System.Windows.Forms.Timer(components);
            timer2=new System.Windows.Forms.Timer(components);
            timer3=new System.Windows.Forms.Timer(components);
            timerBlack=new System.Windows.Forms.Timer(components);
            labelWhiteTimer=new Label();
            labelBlackTimer=new Label();
            StartButton=new Button();
            labelInfoWhite=new Label();
            labelInfoBlack=new Label();
            ((System.ComponentModel.ISupportInitialize)MovesTable).BeginInit();
            SuspendLayout();
            // 
            // FieldPanel
            // 
            FieldPanel.BackgroundImage=Properties.Resources.poster;
            FieldPanel.BorderStyle=BorderStyle.FixedSingle;
            FieldPanel.Location=new Point(329, 75);
            FieldPanel.Name="FieldPanel";
            FieldPanel.Size=new Size(800, 800);
            FieldPanel.TabIndex=0;
            // 
            // RestartBtn
            // 
            RestartBtn.BackColor=SystemColors.MenuHighlight;
            RestartBtn.BackgroundImage=Properties.Resources._1614263474_11_p_cherno_belie_kva;
            RestartBtn.Cursor=Cursors.Hand;
            RestartBtn.Font=new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            RestartBtn.ForeColor=Color.White;
            RestartBtn.Location=new Point(35, 795);
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
            labelMoves.Location=new Point(1178, 195);
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
            MovesTable.Location=new Point(1178, 239);
            MovesTable.Name="MovesTable";
            MovesTable.ReadOnly=true;
            MovesTable.RowHeadersBorderStyle=DataGridViewHeaderBorderStyle.None;
            MovesTable.RowHeadersVisible=false;
            MovesTable.RowHeadersWidth=62;
            MovesTable.RowTemplate.Height=33;
            MovesTable.ScrollBars=ScrollBars.Vertical;
            MovesTable.Size=new Size(354, 494);
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
            // label1
            // 
            label1.AutoSize=true;
            label1.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location=new Point(274, 95);
            label1.Name="label1";
            label1.Size=new Size(49, 60);
            label1.TabIndex=0;
            label1.Text="8";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location=new Point(274, 195);
            label2.Name="label2";
            label2.Size=new Size(49, 60);
            label2.TabIndex=5;
            label2.Text="7";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location=new Point(274, 395);
            label3.Name="label3";
            label3.Size=new Size(49, 60);
            label3.TabIndex=7;
            label3.Text="5";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location=new Point(274, 295);
            label4.Name="label4";
            label4.Size=new Size(49, 60);
            label4.TabIndex=6;
            label4.Text="6";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location=new Point(274, 795);
            label5.Name="label5";
            label5.Size=new Size(49, 60);
            label5.TabIndex=11;
            label5.Text="1";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location=new Point(274, 695);
            label6.Name="label6";
            label6.Size=new Size(49, 60);
            label6.TabIndex=10;
            label6.Text="2";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location=new Point(274, 595);
            label7.Name="label7";
            label7.Size=new Size(49, 60);
            label7.TabIndex=9;
            label7.Text="3";
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location=new Point(274, 495);
            label8.Name="label8";
            label8.Size=new Size(49, 60);
            label8.TabIndex=8;
            label8.Text="4";
            // 
            // label9
            // 
            label9.AutoSize=true;
            label9.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location=new Point(356, 878);
            label9.Name="label9";
            label9.Size=new Size(47, 60);
            label9.TabIndex=12;
            label9.Text="a";
            // 
            // label10
            // 
            label10.AutoSize=true;
            label10.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location=new Point(456, 878);
            label10.Name="label10";
            label10.Size=new Size(51, 60);
            label10.TabIndex=13;
            label10.Text="b";
            // 
            // label11
            // 
            label11.AutoSize=true;
            label11.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location=new Point(656, 878);
            label11.Name="label11";
            label11.Size=new Size(51, 60);
            label11.TabIndex=15;
            label11.Text="d";
            // 
            // label12
            // 
            label12.AutoSize=true;
            label12.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location=new Point(556, 878);
            label12.Name="label12";
            label12.Size=new Size(45, 60);
            label12.TabIndex=14;
            label12.Text="c";
            // 
            // label13
            // 
            label13.AutoSize=true;
            label13.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location=new Point(1056, 878);
            label13.Name="label13";
            label13.Size=new Size(50, 60);
            label13.TabIndex=19;
            label13.Text="h";
            // 
            // label14
            // 
            label14.AutoSize=true;
            label14.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location=new Point(956, 878);
            label14.Name="label14";
            label14.Size=new Size(51, 60);
            label14.TabIndex=18;
            label14.Text="g";
            // 
            // label15
            // 
            label15.AutoSize=true;
            label15.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location=new Point(856, 878);
            label15.Name="label15";
            label15.Size=new Size(39, 60);
            label15.TabIndex=17;
            label15.Text="f";
            // 
            // label16
            // 
            label16.AutoSize=true;
            label16.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location=new Point(756, 878);
            label16.Name="label16";
            label16.Size=new Size(48, 60);
            label16.TabIndex=16;
            label16.Text="e";
            // 
            // timerWhite
            // 
            timerWhite.Interval=1000;
            // 
            // timerBlack
            // 
            timerBlack.Interval=1000;
            // 
            // labelWhiteTimer
            // 
            labelWhiteTimer.AutoSize=true;
            labelWhiteTimer.BackColor=Color.Snow;
            labelWhiteTimer.BorderStyle=BorderStyle.Fixed3D;
            labelWhiteTimer.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            labelWhiteTimer.Location=new Point(1178, 795);
            labelWhiteTimer.Name="labelWhiteTimer";
            labelWhiteTimer.Size=new Size(37, 62);
            labelWhiteTimer.TabIndex=20;
            labelWhiteTimer.Text=":";
            // 
            // labelBlackTimer
            // 
            labelBlackTimer.AutoSize=true;
            labelBlackTimer.BackColor=Color.Snow;
            labelBlackTimer.BorderStyle=BorderStyle.Fixed3D;
            labelBlackTimer.Font=new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            labelBlackTimer.Location=new Point(1178, 95);
            labelBlackTimer.Name="labelBlackTimer";
            labelBlackTimer.Size=new Size(37, 62);
            labelBlackTimer.TabIndex=21;
            labelBlackTimer.Text=":";
            // 
            // StartButton
            // 
            StartButton.BackColor=SystemColors.MenuHighlight;
            StartButton.BackgroundImage=Properties.Resources.kvadrat_cvet_treugolnik_obem_reb;
            StartButton.Cursor=Cursors.Hand;
            StartButton.Font=new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.ForeColor=Color.White;
            StartButton.Location=new Point(35, 95);
            StartButton.Name="StartButton";
            StartButton.Size=new Size(204, 87);
            StartButton.TabIndex=22;
            StartButton.Text="Start";
            StartButton.UseVisualStyleBackColor=false;
            StartButton.Click+=StartButton_Click;
            // 
            // labelInfoWhite
            // 
            labelInfoWhite.AutoSize=true;
            labelInfoWhite.Font=new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labelInfoWhite.ForeColor=Color.FromArgb(64, 64, 64);
            labelInfoWhite.Location=new Point(1391, 797);
            labelInfoWhite.Name="labelInfoWhite";
            labelInfoWhite.Size=new Size(0, 60);
            labelInfoWhite.TabIndex=23;
            // 
            // labelInfoBlack
            // 
            labelInfoBlack.AutoSize=true;
            labelInfoBlack.Font=new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labelInfoBlack.ForeColor=Color.FromArgb(64, 64, 64);
            labelInfoBlack.Location=new Point(1391, 97);
            labelInfoBlack.Name="labelInfoBlack";
            labelInfoBlack.Size=new Size(0, 60);
            labelInfoBlack.TabIndex=24;
            // 
            // GameUI
            // 
            AutoScaleDimensions=new SizeF(10F, 25F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(242, 232, 201);
            ClientSize=new Size(1578, 944);
            Controls.Add(labelInfoBlack);
            Controls.Add(labelInfoWhite);
            Controls.Add(StartButton);
            Controls.Add(labelWhiteTimer);
            Controls.Add(labelBlackTimer);
            Controls.Add(label13);
            Controls.Add(label5);
            Controls.Add(label10);
            Controls.Add(label14);
            Controls.Add(label6);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label15);
            Controls.Add(label8);
            Controls.Add(label12);
            Controls.Add(label3);
            Controls.Add(label16);
            Controls.Add(label4);
            Controls.Add(label11);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MovesTable);
            Controls.Add(labelMoves);
            Controls.Add(RestartBtn);
            Controls.Add(FieldPanel);
            FormBorderStyle=FormBorderStyle.FixedSingle;
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private System.Windows.Forms.Timer timerWhite;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timerBlack;
        private Label labelWhiteTimer;
        private Label labelBlackTimer;
        private Button StartButton;
        private Label labelInfoWhite;
        private Label labelInfoBlack;
    }
}