using System.Windows.Forms;

/* 1 HW
 * 1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полёт в звёздном пространстве.
 * 2. *Заменить кружочки картинками, используя метод DrawImage.
 * 3. *Разработать собственный класс заставка SplashScreen, аналогичный классу Game в котором создайте собственную иерархию объектов и задайте их движение. Предусмотреть кнопки - Начало игры, Рекорды, Выход. Добавить на заставку имя автора.
 */

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form{ Width = 800, Height = 600 };
            form.Show();
            form.FormClosing += Form_FormClosing;
            Game.Init(form);
            Application.Run();
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.timer.Stop();
            Application.Exit();
        }
    }
}
