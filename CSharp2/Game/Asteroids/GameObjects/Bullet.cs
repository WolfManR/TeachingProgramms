using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Bullet : BaseGameObject, ICollision, IResetPos
    {
        readonly int speed;
        public Player Player { get; set; }
        public ICollisionObject CollisionObject { get; }

        public Bullet(Point pos,int speed,Player player):this(pos,new Point(speed,0),new Size(4, 2))
        {
            this.Player = player;
            this.speed = speed;
        }
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.CollisionObject = new RectangleCollision(this);
            this.speed = dir.X;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            if (pos.X < Game.Width + size.Width) pos.X += speed;
        }
        public void ResetPos()
        {
            pos.X = 0;
        }
    }
}
