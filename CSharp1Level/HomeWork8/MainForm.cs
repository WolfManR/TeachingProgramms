using HomeWork8.Forms;
using HomeWorkLib;
using System;
using System.Windows.Forms;

namespace HomeWork8
{
    public partial class MainForm : Form,IHWTaskData
    {
        public string Title => "Домашняя работа";

        public int TaskNumber => 8;

        public string ToDo => "а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок " +
                              "\n(не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.)" +
                              "\nб) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение."+
                              "\nв) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.)." +
                              "\nг) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос." +
                              "\nд) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog)." +
                              "\n\n2. Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю»." +
                              "\n\n3. *Написать программу-преобразователь из CSV в XML-файл с информацией о студентах(6 урок).";

        public MainForm()
        {
            InitializeComponent();
            ttToDO.SetToolTip(btnHelp, ToDo);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGame_Click(object sender, EventArgs e)
        {
            if (Program.DataBase == null)
            {
                MessageBox.Show("сначала необходимо загрузить базу данных с вопросами");
                return;
            }
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

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            var conv = new Converter { Main = this };
            conv.Show();
            Hide();
        }
    }
}
