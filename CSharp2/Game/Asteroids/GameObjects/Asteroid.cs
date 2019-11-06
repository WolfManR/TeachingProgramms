using System.Drawing;
using GameProject.GameEngine;

namespace GameProject.Asteroids.GameObjects
{
    class Asteroid : GameObject, ICollision,IResetPos
    {
        private Rectangle collisionRect;

        public Image Image { get; set; }
        public Rectangle CollisionRect => collisionRect;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            collisionRect = new Rectangle(pos, size);
        }

        public bool Collision(ICollision obj)=>obj.CollisionRect.IntersectsWith(this.CollisionRect);
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0) pos.X = Game.Width + 20;
            collisionRect.Location = pos;
        }

        public void ResetPos()
        {
            pos.X = Game.Width;
        }
    }
}
