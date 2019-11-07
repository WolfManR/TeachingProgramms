using System.Drawing;

namespace GameProject.GameEngine
{
    public abstract class GameObject:IGameEngineObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public GameObject(Point pos, Point dir, Size size)
        {
            if (pos.X > Game.Width + 400 || pos.X < -200 || dir.X > 100 || dir.Y > 100 || dir.X < -100 || dir.Y < -100 || size.Width < 0 || size.Width > Game.Width || size.Height < 0 || size.Height > Game.Height)
                throw new InGameObjects.GameObjectException("Wrong Parameters");
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public abstract void Draw();
        public abstract void Update();
    }
}
