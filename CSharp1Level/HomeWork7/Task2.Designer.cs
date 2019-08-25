namespace HomeWork7
{
    partial class Task2
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
            this.pHeader = new System.Windows.Forms.Panel();
            this.btnAppExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlTpHelp = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitleTryes = new System.Windows.Forms.Label();
            this.lblTitleNumber = new System.Windows.Forms.Label();
            this.gbTryes = new System.Windows.Forms.GroupBox();
            this.lblTryes = new System.Windows.Forms.Label();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.gbGuessNumber = new System.Windows.Forms.GroupBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.lblHowClose = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            this.gbTryes.SuspendLayout();
            this.gbGuessNumber.SuspendLayout();
            this.SuspendLayout();
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
            this.pHeader.TabIndex = 2;
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.lblTitle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTitle.Location = new System.Drawing.Point(198, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(346, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Угадай число";
            // 
            // tlTpHelp
            // 
            this.tlTpHelp.AutoPopDelay = 90000;
            this.tlTpHelp.InitialDelay = 500;
            this.tlTpHelp.IsBalloon = true;
            this.tlTpHelp.ReshowDelay = 100;
            // 
            // lblTitleTryes
            // 
            this.lblTitleTryes.AutoSize = true;
            this.lblTitleTryes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTitleTryes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitleTryes.Location = new System.Drawing.Point(2, 9);
            this.lblTitleTryes.Name = "lblTitleTryes";
            this.lblTitleTryes.Size = new System.Drawing.Size(115, 29);
            this.lblTitleTryes.TabIndex = 0;
            this.lblTitleTryes.Text = "Попыток";
            // 
            // lblTitleNumber
            // 
            this.lblTitleNumber.AutoSize = true;
            this.lblTitleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.lblTitleNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitleNumber.Location = new System.Drawing.Point(6, 16);
            this.lblTitleNumber.Name = "lblTitleNumber";
            this.lblTitleNumber.Size = new System.Drawing.Size(106, 36);
            this.lblTitleNumber.TabIndex = 0;
            this.lblTitleNumber.Text = "Число";
            // 
            // gbTryes
            // 
            this.gbTryes.Controls.Add(this.lblTryes);
            this.gbTryes.Controls.Add(this.lblTitleTryes);
            this.gbTryes.Location = new System.Drawing.Point(264, 136);
            this.gbTryes.Name = "gbTryes";
            this.gbTryes.Size = new System.Drawing.Size(171, 41);
            this.gbTryes.TabIndex = 3;
            this.gbTryes.TabStop = false;
            // 
            // lblTryes
            // 
            this.lblTryes.AutoSize = true;
            this.lblTryes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTryes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTryes.Location = new System.Drawing.Point(123, 9);
            this.lblTryes.Name = "lblTryes";
            this.lblTryes.Size = new System.Drawing.Size(27, 29);
            this.lblTryes.TabIndex = 0;
            this.lblTryes.Text = "0";
            this.lblTryes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAnswer
            // 
            this.tbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.tbAnswer.Location = new System.Drawing.Point(114, 13);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(89, 41);
            this.tbAnswer.TabIndex = 4;
            // 
            // gbGuessNumber
            // 
            this.gbGuessNumber.Controls.Add(this.tbAnswer);
            this.gbGuessNumber.Controls.Add(this.lblTitleNumber);
            this.gbGuessNumber.Location = new System.Drawing.Point(246, 256);
            this.gbGuessNumber.Name = "gbGuessNumber";
            this.gbGuessNumber.Size = new System.Drawing.Size(207, 60);
            this.gbGuessNumber.TabIndex = 3;
            this.gbGuessNumber.TabStop = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNewGame.Location = new System.Drawing.Point(279, 99);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(140, 31);
            this.btnNewGame.TabIndex = 5;
            this.btnNewGame.Text = "Новая игра";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAnswer.Location = new System.Drawing.Point(279, 322);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(140, 31);
            this.btnAnswer.TabIndex = 5;
            this.btnAnswer.Text = "Ответить";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.BtnAnswer_Click);
            // 
            // lblHowClose
            // 
            this.lblHowClose.AutoSize = true;
            this.lblHowClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.lblHowClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblHowClose.Location = new System.Drawing.Point(102, 202);
            this.lblHowClose.Name = "lblHowClose";
            this.lblHowClose.Size = new System.Drawing.Size(495, 36);
            this.lblHowClose.TabIndex = 0;
            this.lblHowClose.Text = "Ваше число больше загаданного";
            this.lblHowClose.UseWaitCursor = true;
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 450);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.lblHowClose);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.gbGuessNumber);
            this.Controls.Add(this.gbTryes);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Task2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task2";
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbTryes.ResumeLayout(false);
            this.gbTryes.PerformLayout();
            this.gbGuessNumber.ResumeLayout(false);
            this.gbGuessNumber.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button btnAppExit;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolTip tlTpHelp;
        private System.Windows.Forms.Label lblTitleTryes;
        private System.Windows.Forms.Label lblTitleNumber;
        private System.Windows.Forms.GroupBox gbTryes;
        private System.Windows.Forms.Label lblTryes;
        private System.Windows.Forms.TextBox tbAnswer;
        private System.Windows.Forms.GroupBox gbGuessNumber;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Label lblHowClose;
    }
}