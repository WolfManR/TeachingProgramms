using GameEngineLibraryProject.Archetipes;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngineLibraryProject
{
    public abstract class Scene : IGameEngineObject
    {
        public List<GameObject> BackGroundObjects { get; set; }
        

        public static void Test()
        {
            // Проверяем вывод графики
            Game.buffer.Graphics.Clear(Color.Black);
            Game.buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Game.buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
        }
        public abstract void Load();
        public abstract void Draw();
        public abstract void Update();
    }
}
