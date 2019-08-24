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
    }
}
