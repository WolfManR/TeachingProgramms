using System.Drawing;

namespace GameProject.GameEngine
{
    public class Player : GameObject, ICollision
    {
        private Rectangle collisionRect;

        public Weapon Weapon { get; set; }
        public Image Image { get; set; }
        public Point WeaponPos { get => new Point(pos.X + size.Width, pos.Y); }
        public Rectangle CollisionRect => collisionRect;

        public Player(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            collisionRect = new Rectangle(pos, size);
        }

        public bool Collision(ICollision obj) => obj.CollisionRect.IntersectsWith(this.CollisionRect);
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
            Weapon.Draw();
        }
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y > Game.Height) dir.Y = -dir.Y;
            Weapon.Update();
            collisionRect.Location = pos;
        }
    }
}