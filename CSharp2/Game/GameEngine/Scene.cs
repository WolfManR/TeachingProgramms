using GameProject.GameObjects;
using System.Collections.Generic;
using System.Drawing;

namespace GameProject.GameEngine
{
    public abstract class Scene:IGameEngineObject
    {
        public List<GameObject> Objects { get; set; }

        public static void Test()
        {
            // Проверяем вывод графики
            Game.buffer.Graphics.Clear(Color.Black);
            Game.buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Game.buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
        }
        public abstract void Load();
        public virtual void Draw()
        {
            Game.buffer.Graphics.Clear(Color.Black);
            foreach (GameObject obj in Objects)
                obj.Draw();
            Game.buffer.Render();
        }

        public virtual void Update()
        {
            foreach (GameObject obj in Objects) obj.Update();
        }
    }
}
