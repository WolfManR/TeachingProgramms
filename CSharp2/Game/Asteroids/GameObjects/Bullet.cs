using System.Drawing;
using GameProject.GameEngine;

namespace GameProject.Asteroids.GameObjects
{
    class Bullet : GameObject, ICollision,IResetPos
    {
        private Rectangle collisionRect;

        public Rectangle CollisionRect => collisionRect; 
        public Bullet() : this(new Point(), new Point(), new Size(4, 2))
        {

        }
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            collisionRect = new Rectangle(pos, size);
        }

        public bool Collision(ICollision obj)
        {
            bool check = obj.CollisionRect.IntersectsWith(this.CollisionRect);
            if (check) 
            { 
                ResetPos();
                (obj as IResetPos).ResetPos();
            }
            return check;
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X > Game.Width) dir.X = 0;
            collisionRect.Location = pos;
        }

        public void ResetPos()
        {
            pos.X = 0;
        }
    }
}
