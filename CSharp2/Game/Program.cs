using System;
using System.Windows.Forms;
using GameEngineLibraryProject;
using GameProject.Asteroids;
using System.IO;
namespace GameProject
{
    public delegate void Log(object sender, string msg);
    public static class Program
    {
        public static Log Log { get; set; }
        static void Main(string[] args)
        {
            Log = new Log(ConsoleWork.Message);
            ConsoleWork.OpenStream();
            Log += ConsoleWork.SaveLogToFile;
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
            Log -= ConsoleWork.SaveLogToFile;                 //интересный баг если не убрать, подскажите почему
            ConsoleWork.CloseStream();
        }
    }
    
    public static class ConsoleWork
    {
        public static void Message(object sender,string msg)
        {
            Console.WriteLine($"{sender?.GetType().Name} {msg}");
        }
        static StreamWriter sw;

        public static void OpenStream()
        {
            try
            {
                sw = new StreamWriter("Log.txt");
            }
            catch (Exception)
            {

                throw new Exception("can't open stream");
            }
        }

        public static void CloseStream()
        {
            sw?.Close();
        }
        public static void SaveLogToFile(object sender, string msg)
        {
            //try
            //{
                sw?.WriteLine($"{sender?.GetType().Name} {msg}");
            //}
            //catch (Exception)
            //{
            //    throw new Exception("cant wright in stream");
            //}
            
        }
    }
}
