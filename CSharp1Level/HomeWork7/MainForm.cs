using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnUdvoitel_Click(object sender, EventArgs e)
        {
            var task1 = new Task1();
            task1.Main = this;
            task1.Show();
            Hide();
        }
        private void BtnCheckNumber_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
