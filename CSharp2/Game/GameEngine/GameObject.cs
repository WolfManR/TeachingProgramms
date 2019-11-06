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
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public abstract void Draw();
        public abstract void Update();
    }
}
