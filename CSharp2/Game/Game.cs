using GameProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        // Свойства
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }

        static public GameObject[] objs;
        static public Timer timer;

        static Game()
        {
        }

        static public void Init(Form form)
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
            Load();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (sender,e) =>
            {
                Draw();
                Update();
            };
            timer.Start();
        }

        static public void Load()
        {
            objs = new GameObject[30];
            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new GameObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
            Star.Image = Image.FromFile(@"Assets/star.png");
            for (int i = 15; i < objs.Length; i++)
                objs[i] = new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
        }


        static public void Draw()
        {
            // Проверяем вывод графики
            buffer.Graphics.Clear(Color.Black);
            //buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            foreach (GameObject obj in objs)
                obj.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            foreach (GameObject obj in objs) obj.Update();
        }
    }
}
