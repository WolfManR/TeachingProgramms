using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Bullet : BaseGameObject, ICollision, IDamagedObject
    {
        readonly int speed;

        public Player Player { get; set; }
        public ILightWeightCollisionObject CollisionObject { get; }
        public int Health { get; private set; }
        public int Damage { get; }
        public int BaseHealth { get; }
        public bool IsDestroyed { get; private set; } = false;

        public Bullet(Point pos, int speed, Player player, int health, int damage) : this(pos, new Point(speed, 0), new Size(4, 2))
        {
            this.Player = player;
            this.speed = speed;
            this.Health = health;
            this.BaseHealth = health;
            this.Damage = damage;
        }
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            var RCol = new RectangleCollision(this);
            RCol.Intersected += DoDamage;
            this.CollisionObject = RCol;
            this.speed = dir.X;

            Program.Log?.Invoke(this, "Created");
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);

            Program.Log?.Invoke(this, "Drawn");
        }
        public override void Update()
        {
            if (pos.X < Game.Width + size.Width) pos.X += speed;

            Program.Log?.Invoke(this, "Updated");
        }
        public void DoDamage(object sender, object obj)
        {
            if (obj is IDamagedObject d)
            {
                Damaged(d, d.Damage);
                d.Damaged(this.Player, Damage);
            }

            Program.Log?.Invoke(this, $"Damage {obj.GetType().Name} on {Damage} points");
        }
        public void Damaged(object obj, int value)
        {
            if (Health > 0 && Health - value > 0) Health -= value;
            else IsDestroyed = true;

            Program.Log?.Invoke(this, $"Damaged by {obj.GetType().Name} on {value} points");
        }
    }
}
