using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Ship : BaseGameObject, ICollision
    {
        public new Point Pos { get => pos; set => pos = value; }
        public Image Image { get; set; }
        public ICollisionObject CollisionObject { get; }
        public Point WeaponPos { get => new Point(pos.X + size.Width, pos.Y-size.Height/2); }
        public Player Player { get; set; }
        public Ship(Point dir, Image image, Player player) : this(new Point(0, 0), dir, new Size(image.Width, image.Height))
        {
            this.Image = image;
            this.Player = player;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            CollisionObject = new RectangleCollision(this);
        }


        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
        public override void Update()
        {
        }
        public Bullet Shoot() => new Bullet(WeaponPos, 5, this.Player);
        public void MoveUp()
        {
            if(pos.Y<0)pos.Y += dir.Y;
        }
        public void MoveDown()
        {
            if(pos.Y+size.Height>Game.Height)pos.Y -= dir.Y;
        }
    }
}
