namespace HomeWork7
{
    partial class MainForm
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
            this.btnUdvoitel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCheckNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUdvoitel
            // 
            this.btnUdvoitel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUdvoitel.Location = new System.Drawing.Point(199, 151);
            this.btnUdvoitel.Name = "btnUdvoitel";
            this.btnUdvoitel.Size = new System.Drawing.Size(210, 47);
            this.btnUdvoitel.TabIndex = 0;
            this.btnUdvoitel.Text = "Удвоитель";
            this.btnUdvoitel.UseVisualStyleBackColor = true;
            this.btnUdvoitel.Click += new System.EventHandler(this.btnUdvoitel_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(225, 257);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(158, 47);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnCheckNumber
            // 
            this.btnCheckNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckNumber.Location = new System.Drawing.Point(199, 204);
            this.btnCheckNumber.Name = "btnCheckNumber";
            this.btnCheckNumber.Size = new System.Drawing.Size(210, 47);
            this.btnCheckNumber.TabIndex = 0;
            this.btnCheckNumber.Text = "Угадай число";
            this.btnCheckNumber.UseVisualStyleBackColor = true;
            this.btnCheckNumber.Click += new System.EventHandler(this.BtnCheckNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(212, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "Игры";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCheckNumber);
            this.Controls.Add(this.btnUdvoitel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUdvoitel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCheckNumber;
        private System.Windows.Forms.Label label1;
    }
}

