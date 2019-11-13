using System;
using System.Windows.Forms;
using GameEngineLibraryProject;
using GameProject.Asteroids;

namespace GameProject
{
    public delegate void Log(object sender, string msg);
    public static class Program
    {
        public static Log Log { get; set; }
        static void Main(string[] args)
        {
            Log = new Log(ConsoleWork.Message);
            Log?.Invoke(null, "GameProject Work Started");
            try
            {
                Form form = new Form { Width = 800, Height = 600 };
                form.Show();
                form.FormClosing += Form_FormClosing;
                Game.Init(form.CreateGraphics(),form.Width,form.Height);
                Log?.Invoke(null, "GameEngine Initialized");
                MainGame.Init("Player1");               //Получить ответ из DialogResult
                Log?.Invoke(null, "MainGame Initialized");
                SplashScreen.Init(form);
                Log?.Invoke(null, "SplashScreen Initialized");
                Application.Run(form);
                Log?.Invoke(null, "Application Run");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Log?.Invoke(null, "GameProject Work Failed");
            }
            finally
            {
                Log?.Invoke(null, "GameProject Work Finished");
            }
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.Timer.Stop();
            Log?.Invoke(null, "Form Closing");
        }
    }
    
    public static class ConsoleWork
    {
        public static void Message(object sender,string msg)
        {
            Console.WriteLine($"{sender?.GetType().Name} {msg}");
        }

        public static void SaveLogToFile(object sender, string msg)
        {

        }
    }
}
