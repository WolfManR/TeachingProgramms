using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameProject.GameEngine
{
    public abstract class Scene : IGameEngineObject
    {
        private List<GameObject> collisionsObjects;

        public List<GameObject> Objects { get; set; }
        public List<GameObject> CollisionsObjects 
        { 
            get => collisionsObjects;
            set {
                foreach (var item in value)
                    if (!(item is ICollision)) throw new ArgumentException("This collection support only ICollection objects");
                collisionsObjects = value;
            } 
        }
        public Player Player { get; set; }

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
            foreach (GameObject obj in Objects) obj.Draw();
            foreach (GameObject obj in CollisionsObjects) obj.Draw();
            Player.Draw();
            Game.buffer.Render();
        }

        public virtual void Update()
        {
            foreach (GameObject obj in Objects) obj.Update();
            foreach (GameObject obj in CollisionsObjects)
            {
                obj.Update();
                if(Player.Weapon.DamageArea.Collision(obj as ICollision)) System.Media.SystemSounds.Hand.Play();
            }
            Player.Update();
        }
    }
}
