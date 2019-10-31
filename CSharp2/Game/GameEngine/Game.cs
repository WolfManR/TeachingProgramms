using GameProject.Asteroids;
using GameProject.Asteroids.GameLevels;
using GameProject.GameEngine;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    static class Game
    {
        static BufferedGraphicsContext context;
        public static BufferedGraphics buffer;
        
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static Timer timer;
        public static Scene Scene { get; set; }
        static Game()
        {
        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
                                      // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            SplashScreen.Init(form);

            timer = new Timer { Interval = 100 };
            timer.Tick += (sender, e) =>
            {
                Scene.Draw();
                Scene.Update();
            };
        }

        public static void Play()
        {
            Scene.Load();
            timer.Start();
        }

    }
}
