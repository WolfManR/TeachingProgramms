﻿using System.Windows.Forms;
using GameEngineLibraryProject;
using GameProject.Asteroids;
/* 1 HW
* 1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полёт в звёздном пространстве.
* 2. *Заменить кружочки картинками, используя метод DrawImage.
* 3. *Разработать собственный класс заставка SplashScreen, аналогичный классу Game в котором создайте собственную иерархию объектов и задайте их движение. Предусмотреть кнопки - Начало игры, Рекорды, Выход. Добавить на заставку имя автора.
*/


/* 2 HW
* 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
* 3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
* 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
* 5. *Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость или позиция).
*/
namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
                Form form = new Form { Width = 800, Height = 600 };
                form.Show();
                form.FormClosing += Form_FormClosing;
                Game.Init(form.CreateGraphics(),form.Width,form.Height);
                MainGame.Init("Player1");               //Получить ответ из DialogResult
                SplashScreen.Init(form);
                Application.Run(form);
            //}
            //catch (System.Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}
            
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.Timer.Stop();
        }
    }
}
