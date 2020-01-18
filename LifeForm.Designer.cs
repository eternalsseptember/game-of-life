namespace ConwayGameOfLife
{
    partial class LifeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LifeForm));
			this.gamePanel = new System.Windows.Forms.Panel();
			this.newGameBtn = new System.Windows.Forms.Button();
			this.pauseBtn = new System.Windows.Forms.Button();
			this.nextBtn = new System.Windows.Forms.Button();
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.genDesc = new System.Windows.Forms.Label();
			this.genLabel = new System.Windows.Forms.Label();
			this.UPSControl = new System.Windows.Forms.TrackBar();
			this.popDesc = new System.Windows.Forms.Label();
			this.popLabel = new System.Windows.Forms.Label();
			this.patternBox = new System.Windows.Forms.ComboBox();
			this.resetBtn = new System.Windows.Forms.Button();
			this.randomBtn = new System.Windows.Forms.Button();
			this.gameToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.prevBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.UPSControl)).BeginInit();
			this.SuspendLayout();
			// 
			// gamePanel
			// 
			this.gamePanel.BackColor = System.Drawing.Color.Black;
			this.gamePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.gamePanel.Location = new System.Drawing.Point(0, 0);
			this.gamePanel.Name = "gamePanel";
			this.gamePanel.Size = new System.Drawing.Size(1063, 505);
			this.gamePanel.TabIndex = 0;
			this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridClick);
			// 
			// newGameBtn
			// 
			this.newGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.newGameBtn.ForeColor = System.Drawing.Color.SeaShell;
			this.newGameBtn.Image = ((System.Drawing.Image)(resources.GetObject("newGameBtn.Image")));
			this.newGameBtn.Location = new System.Drawing.Point(193, 517);
			this.newGameBtn.Name = "newGameBtn";
			this.newGameBtn.Size = new System.Drawing.Size(45, 45);
			this.newGameBtn.TabIndex = 1;
			this.gameToolTip.SetToolTip(this.newGameBtn, "Start new game");
			this.newGameBtn.UseVisualStyleBackColor = true;
			this.newGameBtn.Click += new System.EventHandler(this.NewGameClick);
			// 
			// pauseBtn
			// 
			this.pauseBtn.BackColor = System.Drawing.Color.SeaShell;
			this.pauseBtn.Enabled = false;
			this.pauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.pauseBtn.ForeColor = System.Drawing.Color.SeaShell;
			this.pauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseBtn.Image")));
			this.pauseBtn.Location = new System.Drawing.Point(295, 517);
			this.pauseBtn.Name = "pauseBtn";
			this.pauseBtn.Size = new System.Drawing.Size(45, 45);
			this.pauseBtn.TabIndex = 2;
			this.pauseBtn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.gameToolTip.SetToolTip(this.pauseBtn, "Pause/Continue");
			this.pauseBtn.UseVisualStyleBackColor = false;
			this.pauseBtn.Click += new System.EventHandler(this.PauseClick);
			// 
			// nextBtn
			// 
			this.nextBtn.Enabled = false;
			this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nextBtn.ForeColor = System.Drawing.Color.SeaShell;
			this.nextBtn.Image = ((System.Drawing.Image)(resources.GetObject("nextBtn.Image")));
			this.nextBtn.Location = new System.Drawing.Point(346, 517);
			this.nextBtn.Name = "nextBtn";
			this.nextBtn.Size = new System.Drawing.Size(45, 45);
			this.nextBtn.TabIndex = 3;
			this.gameToolTip.SetToolTip(this.nextBtn, "Next one step");
			this.nextBtn.UseVisualStyleBackColor = true;
			this.nextBtn.Click += new System.EventHandler(this.NextStepBtnClick);
			// 
			// gameTimer
			// 
			this.gameTimer.Tick += new System.EventHandler(this.TimerTick);
			// 
			// genDesc
			// 
			this.genDesc.AutoSize = true;
			this.genDesc.Location = new System.Drawing.Point(830, 517);
			this.genDesc.Name = "genDesc";
			this.genDesc.Size = new System.Drawing.Size(62, 13);
			this.genDesc.TabIndex = 5;
			this.genDesc.Text = "Generation:";
			// 
			// genLabel
			// 
			this.genLabel.AutoSize = true;
			this.genLabel.Location = new System.Drawing.Point(898, 517);
			this.genLabel.Name = "genLabel";
			this.genLabel.Size = new System.Drawing.Size(13, 13);
			this.genLabel.TabIndex = 7;
			this.genLabel.Text = "0";
			// 
			// UPSControl
			// 
			this.UPSControl.Location = new System.Drawing.Point(467, 529);
			this.UPSControl.Maximum = 500;
			this.UPSControl.Minimum = 1;
			this.UPSControl.Name = "UPSControl";
			this.UPSControl.Size = new System.Drawing.Size(188, 45);
			this.UPSControl.SmallChange = 100;
			this.UPSControl.TabIndex = 9;
			this.UPSControl.TickFrequency = 100;
			this.UPSControl.Value = 400;
			this.UPSControl.Scroll += new System.EventHandler(this.TimeScroll);
			// 
			// popDesc
			// 
			this.popDesc.AutoSize = true;
			this.popDesc.Location = new System.Drawing.Point(956, 517);
			this.popDesc.Name = "popDesc";
			this.popDesc.Size = new System.Drawing.Size(60, 13);
			this.popDesc.TabIndex = 10;
			this.popDesc.Text = "Population:";
			// 
			// popLabel
			// 
			this.popLabel.AutoSize = true;
			this.popLabel.Location = new System.Drawing.Point(1022, 517);
			this.popLabel.Name = "popLabel";
			this.popLabel.Size = new System.Drawing.Size(13, 13);
			this.popLabel.TabIndex = 11;
			this.popLabel.Text = "0";
			// 
			// patternBox
			// 
			this.patternBox.FormattingEnabled = true;
			this.patternBox.Items.AddRange(new object[] {
            "OneCell",
            "Blinker",
            "Block",
            "Glider",
            "Python",
            "ZdrShip"});
			this.patternBox.Location = new System.Drawing.Point(12, 541);
			this.patternBox.Name = "patternBox";
			this.patternBox.Size = new System.Drawing.Size(160, 21);
			this.patternBox.TabIndex = 12;
			this.patternBox.Text = "...";
			// 
			// resetBtn
			// 
			this.resetBtn.Enabled = false;
			this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.resetBtn.ForeColor = System.Drawing.Color.SeaShell;
			this.resetBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetBtn.Image")));
			this.resetBtn.Location = new System.Drawing.Point(397, 517);
			this.resetBtn.Name = "resetBtn";
			this.resetBtn.Size = new System.Drawing.Size(45, 45);
			this.resetBtn.TabIndex = 13;
			this.gameToolTip.SetToolTip(this.resetBtn, "Reset field");
			this.resetBtn.UseVisualStyleBackColor = true;
			this.resetBtn.Click += new System.EventHandler(this.ResetBtnClick);
			// 
			// randomBtn
			// 
			this.randomBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.randomBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.randomBtn.Location = new System.Drawing.Point(12, 517);
			this.randomBtn.Name = "randomBtn";
			this.randomBtn.Size = new System.Drawing.Size(160, 21);
			this.randomBtn.TabIndex = 14;
			this.randomBtn.Text = "RANDOM PATTERN";
			this.gameToolTip.SetToolTip(this.randomBtn, "Start new game with random pattern");
			this.randomBtn.UseVisualStyleBackColor = true;
			this.randomBtn.Click += new System.EventHandler(this.RandomPatternClick);
			// 
			// gameToolTip
			// 
			this.gameToolTip.AutoPopDelay = 5000;
			this.gameToolTip.InitialDelay = 400;
			this.gameToolTip.ReshowDelay = 300;
			// 
			// prevBtn
			// 
			this.prevBtn.Enabled = false;
			this.prevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.prevBtn.ForeColor = System.Drawing.Color.SeaShell;
			this.prevBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevBtn.Image")));
			this.prevBtn.Location = new System.Drawing.Point(244, 517);
			this.prevBtn.Name = "prevBtn";
			this.prevBtn.Size = new System.Drawing.Size(45, 45);
			this.prevBtn.TabIndex = 15;
			this.gameToolTip.SetToolTip(this.prevBtn, "Previous one step");
			this.prevBtn.UseVisualStyleBackColor = true;
			this.prevBtn.Click += new System.EventHandler(this.PrevStepBtnClick);
			// 
			// LifeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SeaShell;
			this.ClientSize = new System.Drawing.Size(1063, 572);
			this.Controls.Add(this.prevBtn);
			this.Controls.Add(this.randomBtn);
			this.Controls.Add(this.resetBtn);
			this.Controls.Add(this.UPSControl);
			this.Controls.Add(this.patternBox);
			this.Controls.Add(this.popLabel);
			this.Controls.Add(this.popDesc);
			this.Controls.Add(this.genLabel);
			this.Controls.Add(this.genDesc);
			this.Controls.Add(this.gamePanel);
			this.Controls.Add(this.nextBtn);
			this.Controls.Add(this.newGameBtn);
			this.Controls.Add(this.pauseBtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1079, 611);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1079, 611);
			this.Name = "LifeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Conway\'s Game of Life";
			this.Load += new System.EventHandler(this.Loading);
			((System.ComponentModel.ISupportInitialize)(this.UPSControl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button newGameBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label genDesc;
        private System.Windows.Forms.Label genLabel;
        private System.Windows.Forms.TrackBar UPSControl;
        private System.Windows.Forms.Label popDesc;
        private System.Windows.Forms.Label popLabel;
        private System.Windows.Forms.ComboBox patternBox;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button randomBtn;
        private System.Windows.Forms.ToolTip gameToolTip;
        private System.Windows.Forms.Button prevBtn;
    }
}

