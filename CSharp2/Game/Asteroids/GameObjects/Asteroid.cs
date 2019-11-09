using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Asteroid : BaseGameObject, ICollision, IResetPos
    {
        public Image Image { get; set; }
        public ICollisionObject CollisionObject { get; }

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            CollisionObject = new RectangleCollision(this);
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0) pos.X = Game.Width + 20;
        }
        public void ResetPos()
        {
            pos.X = Game.Width;
        }
    }
}
