using System.Drawing;
using GameProject.GameEngine;

namespace GameProject.Asteroids.GameObjects
{
    class Bullet : GameObject,ICollision
    {
        public Rectangle CollisionRect => new Rectangle(pos, size);
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public bool Collision(ICollision obj) => obj.CollisionRect.IntersectsWith(this.CollisionRect);
        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0) pos.X = Game.Width + 20;
        }
    }
}
