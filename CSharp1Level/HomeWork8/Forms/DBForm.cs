using System;
using System.Windows.Forms;

namespace HomeWork8.Forms
{
    public partial class DBForm : Form
    {
        public MainForm Main { get; set; }
        public DBForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Main.Close();
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
    }
}
