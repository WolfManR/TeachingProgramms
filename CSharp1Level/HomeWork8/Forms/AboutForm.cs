using System;
using System.Windows.Forms;

namespace HomeWork8.Forms
{
    public partial class AboutForm : Form
    {
        public MainForm Main { get; set; }
        public AboutForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Main.Enabled = true;
            Close();
        }
    }
}
