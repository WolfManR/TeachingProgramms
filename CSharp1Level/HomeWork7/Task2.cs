using HomeWork7.Code;
using HomeWorkLib;
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
    public partial class Task2 : Form,IHWTaskData
    {
        public MainForm Main { get; set; }
        GuessNumber Game;
        public string Title => "Угадай число";
        public int TaskNumber => 2;
        public string ToDo => "Используя Windows Forms, разработать игру «Угадай число». " +
                              "\nКомпьютер загадывает число от 1 до 100, " +
                              "\nа человек пытается его угадать за минимальное число попыток." +
                              "\nДля ввода данных от человека используется элемент TextBox.";

        public Task2()
        {
            InitializeComponent();
            lblTitle.Text = Title;
            tlTpHelp.SetToolTip(btnHelp, ToDo);
            Game = new GuessNumber(8);
            NewGame();
            Game.Won += (sender, e) =>
            {
                SwitchOffGameBtns();
                MessageBox.Show(e.msg);
            };
            Game.Lost += (sender, e) =>
            {
                SwitchOffGameBtns();
                MessageBox.Show(e.msg);
            };
            Game.HowClose += (sender, e) => lblHowClose.Text = e.msg;
        }

        void SwitchOffGameBtns()
        {
            btnAnswer.Enabled = false;
        }
        void SwitchOnGameBtns()
        {
            btnAnswer.Enabled = true;
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            Main.Show();
            this.Close();
        }

        private void BtnAppExit_Click(object sender, EventArgs e)
        {
            Main.Close();
        }

        void NewGame()
        {
            SwitchOnGameBtns();
            Game.NewGame();
            lblTryes.Text = Game.TryesLeft.ToString();
            lblHowClose.Text = "";
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void BtnAnswer_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (int.TryParse(tbAnswer.Text, out num))
            {
                Game.CheckNumber(num);
                lblTryes.Text=Game.TryesLeft.ToString();
            }
            else MessageBox.Show("Введите целое число");
        }
    }
}
