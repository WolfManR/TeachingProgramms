using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
