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
        Udvoitel Game = new Udvoitel(new Random().Next(1, 101));
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
            if (Game == null)
            {
                MessageBox.Show("Начни игру!");
                return;
            }
            Game.Plus();
            lblCurrent.Text = Game.Current.ToString();
        }

        private void BtnMulti_Click(object sender, EventArgs e)
        {
            if (Game == null)
            {
                MessageBox.Show("Начни игру!");
                return;
            }
            Game.Multi();
            lblCurrent.Text = Game.Current.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Game?.Reset();
            lblCurrent.Text = Game?.Current.ToString();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            Game = new Udvoitel(new Random().Next(1, 101));
            lblNumber.Text = Game.Number.ToString();
            lblCurrent.Text = Game.Current.ToString();
        }
    }
}
