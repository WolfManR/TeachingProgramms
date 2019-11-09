using System.Drawing;

namespace GameEngineLibraryProject.Archetipes
{
    public abstract class GameObject : IGameEngineObject,ISharedGameObjectData
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        public Point Pos => this.pos;
        public Size Size => this.size;

        protected GameObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public abstract void Draw();
        public abstract void Update();
    }
}
