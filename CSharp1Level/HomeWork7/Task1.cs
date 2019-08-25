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
    public partial class Task1 : Form,IHWTaskData
    {
        public MainForm Main { get; set; }
        Udvoitel Game;
        public string Title => "Удвоитель";
        public int TaskNumber => 1;
        public string ToDo => "а) Добавить в программу «Удвоитель» подсчет количества отданных команд." +
                              "\nб) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок." +
                              "\nИгрок должен постараться получить это число за минимальное количество ходов." +
                              "\nв) * Добавить кнопку «Отменить», которая отменяет последние ходы.";
        public Task1()
        {
            InitializeComponent();
            lblTitle.Text = Title;
            tlTpHelp.SetToolTip(btnHelp, ToDo);
            Game = new Udvoitel();
            NewGame();
            Game.Wined += (sender, e) => 
            {
                SwitchOffGameBtns();
                MessageBox.Show(e.msg);
            };
            Game.Loosed += (sender, e) =>
            {
                SwitchOffGameBtns();
                MessageBox.Show(e.msg);
            };
        }

        void SwitchOffGameBtns()
        {
            btnAdd.Enabled = false;
            btnBack.Enabled = false;
            btnMulti.Enabled = false;
            btnReset.Enabled = false;
        }
        void SwitchOnGameBtns()
        {
            btnAdd.Enabled = true;
            btnBack.Enabled = true;
            btnMulti.Enabled = true;
            btnReset.Enabled = true;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Game.Add();
            PlayerMove();
        }

        private void BtnMulti_Click(object sender, EventArgs e)
        {
            Game.Multi();
            PlayerMove();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Game.Reset();
            PlayerMove();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Game.BackStep();
            PlayerMove();
        }
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        void NewGame()
        {
            Game.NewGame();
            lblNumber.Text = Game.Number.ToString();
            lblCurrent.Text = Game.Current.ToString();
            lblStepsToFinish.Text = Game.StepsToFinish.ToString();
            SwitchOnGameBtns();
        }
        void PlayerMove()
        {
            lblCurrent.Text = Game?.Current.ToString();
            lblStepsToFinish.Text = Game.StepsToFinish.ToString();
        }

    }
}
