namespace HomeWork7
{
    partial class Task1
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pHeader = new System.Windows.Forms.Panel();
            this.btnAppExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.tlTpHelp = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblTitleNow = new System.Windows.Forms.Label();
            this.lblTitleNeed = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbGame = new System.Windows.Forms.GroupBox();
            this.LblTitleStepsToFinish = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStepsToFinish = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            this.gbGame.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.lblTitle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTitle.Location = new System.Drawing.Point(223, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(279, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Удвоитель";
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pHeader.Controls.Add(this.btnAppExit);
            this.pHeader.Controls.Add(this.btnHelp);
            this.pHeader.Controls.Add(this.btnBackToMain);
            this.pHeader.Controls.Add(this.lblTitle);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(717, 81);
            this.pHeader.TabIndex = 1;
            // 
            // btnAppExit
            // 
            this.btnAppExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAppExit.Location = new System.Drawing.Point(672, 12);
            this.btnAppExit.Name = "btnAppExit";
            this.btnAppExit.Size = new System.Drawing.Size(33, 31);
            this.btnAppExit.TabIndex = 1;
            this.btnAppExit.Text = "X";
            this.btnAppExit.UseVisualStyleBackColor = true;
            this.btnAppExit.Click += new System.EventHandler(this.BtnAppExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnHelp.Location = new System.Drawing.Point(633, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(33, 31);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnBackToMain.Location = new System.Drawing.Point(13, 12);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(33, 31);
            this.btnBackToMain.TabIndex = 1;
            this.btnBackToMain.Text = "<";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.BtnBackToMain_Click);
            // 
            // tlTpHelp
            // 
            this.tlTpHelp.AutoPopDelay = 90000;
            this.tlTpHelp.InitialDelay = 500;
            this.tlTpHelp.IsBalloon = true;
            this.tlTpHelp.ReshowDelay = 100;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(29, 118);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 31);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+1";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnMulti.Location = new System.Drawing.Point(135, 118);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(80, 31);
            this.btnMulti.TabIndex = 1;
            this.btnMulti.Text = "x2";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Click += new System.EventHandler(this.BtnMulti_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(305, 87);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 31);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNewGame.Location = new System.Drawing.Point(159, 87);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(140, 31);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "Новая игра";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // lblTitleNow
            // 
            this.lblTitleNow.AutoSize = true;
            this.lblTitleNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTitleNow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitleNow.Location = new System.Drawing.Point(20, 60);
            this.lblTitleNow.Name = "lblTitleNow";
            this.lblTitleNow.Size = new System.Drawing.Size(117, 29);
            this.lblTitleNow.TabIndex = 0;
            this.lblTitleNow.Text = "Текущее";
            // 
            // lblTitleNeed
            // 
            this.lblTitleNeed.AutoSize = true;
            this.lblTitleNeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTitleNeed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitleNeed.Location = new System.Drawing.Point(20, 16);
            this.lblTitleNeed.Name = "lblTitleNeed";
            this.lblTitleNeed.Size = new System.Drawing.Size(152, 29);
            this.lblTitleNeed.TabIndex = 0;
            this.lblTitleNeed.Text = "Загаданное";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblNumber.Location = new System.Drawing.Point(188, 19);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(27, 29);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "9";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCurrent.Location = new System.Drawing.Point(188, 63);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(27, 29);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "0";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(411, 87);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 31);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Отмена";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // gbGame
            // 
            this.gbGame.Controls.Add(this.lblTitleNow);
            this.gbGame.Controls.Add(this.btnAdd);
            this.gbGame.Controls.Add(this.btnMulti);
            this.gbGame.Controls.Add(this.lblCurrent);
            this.gbGame.Controls.Add(this.lblTitleNeed);
            this.gbGame.Controls.Add(this.lblNumber);
            this.gbGame.Location = new System.Drawing.Point(233, 192);
            this.gbGame.Name = "gbGame";
            this.gbGame.Size = new System.Drawing.Size(237, 157);
            this.gbGame.TabIndex = 2;
            this.gbGame.TabStop = false;
            // 
            // LblTitleStepsToFinish
            // 
            this.LblTitleStepsToFinish.AutoSize = true;
            this.LblTitleStepsToFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.LblTitleStepsToFinish.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblTitleStepsToFinish.Location = new System.Drawing.Point(6, 9);
            this.LblTitleStepsToFinish.Name = "LblTitleStepsToFinish";
            this.LblTitleStepsToFinish.Size = new System.Drawing.Size(86, 29);
            this.LblTitleStepsToFinish.TabIndex = 0;
            this.LblTitleStepsToFinish.Text = "Ходов";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblTitleStepsToFinish);
            this.groupBox1.Controls.Add(this.lblStepsToFinish);
            this.groupBox1.Location = new System.Drawing.Point(277, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 41);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblStepsToFinish
            // 
            this.lblStepsToFinish.AutoSize = true;
            this.lblStepsToFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblStepsToFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblStepsToFinish.Location = new System.Drawing.Point(123, 9);
            this.lblStepsToFinish.Name = "lblStepsToFinish";
            this.lblStepsToFinish.Size = new System.Drawing.Size(27, 29);
            this.lblStepsToFinish.TabIndex = 0;
            this.lblStepsToFinish.Text = "0";
            this.lblStepsToFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbGame);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Task1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task1";
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbGame.ResumeLayout(false);
            this.gbGame.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button btnAppExit;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.ToolTip tlTpHelp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblTitleNow;
        private System.Windows.Forms.Label lblTitleNeed;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox gbGame;
        private System.Windows.Forms.Label LblTitleStepsToFinish;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStepsToFinish;
    }
}