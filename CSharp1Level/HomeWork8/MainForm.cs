using HomeWork8.Forms;
using System;
using System.Windows.Forms;

namespace HomeWork8
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGame_Click(object sender, EventArgs e)
        {
            var game = new GameForm { Main = this };
            game.Show();
            Hide();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutForm { Main=this};
            about.Show();
            Enabled = false;
        }

        private void BtnDB_Click(object sender, EventArgs e)
        {
            var db = new DBForm { Main=this};
            db.Show();
            Hide();
        }
    }
}
