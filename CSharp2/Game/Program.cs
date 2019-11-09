using System.Windows.Forms;
using GameEngineLibraryProject;
using GameProject.Asteroids;

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
