using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Ship : BaseGameObject, ICollision,IDamagedObject
    {
        public delegate void Message();

        public event Message Died;
        public new Point Pos { get => pos; set => pos = value; }
        public Image Image { get; set; }
        public ILightWeightCollisionObject CollisionObject { get; }
        public Point WeaponPos { get => new Point(pos.X + size.Width, pos.Y + size.Height / 2); }
        public Player Player { get; set; }
        public int Health { get; private set; }
        public int Damage { get; }
        public int BaseHealth { get; }
        public bool IsDestroyed { get; private set; } = false;

        public Ship(Point dir, Image image, int health, int damage) : this(new Point(0, 0), dir, new Size(image.Width, image.Height))
        {
            this.Image = image;
            this.Health = health;
            this.BaseHealth = health;
            this.Damage = damage;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            var RCol = new RectangleCollision(this);
            RCol.Intersected += DoDamage;
            this.CollisionObject = RCol;
            Program.Log?.Invoke(this,"Created");
        }


        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
            Program.Log?.Invoke(this, "Drawn");
        }
        public override void Update()
        {
        }
        public Bullet Shoot()
        {
            Program.Log?.Invoke(this, "Shoot");
            return new Bullet(WeaponPos, 5, this.Player, 3, 8);
        }
        public void MoveUp()
        {
            if (pos.Y > 0) pos.Y -= dir.Y;
            Program.Log?.Invoke(this, "Moved Up");
        }
        public void MoveDown()
        {
            if (pos.Y + size.Height < Game.Height) pos.Y += dir.Y;
            Program.Log?.Invoke(this, "Moved Down");
        }
        public void DoDamage(object sender, object obj)
        {
            switch (obj)
            {
                case IDamagedObject d:
                    Damaged(d, d.Damage);
                    d.Damaged(this.Player, Damage);
                    break;
                case IBonusObject b:
                    b.Bonus(this);
                    break;
                default:
                    break;
            }
            Program.Log?.Invoke(this, $"Damage to {obj.GetType().Name} on {Damage} points");
        }
        public void Damaged(object obj, int value)
        {
            if (Health > 0 && Health - value > 0) Health -= value;
            else Died?.Invoke();
            Program.Log?.Invoke(this, $"Damaged by {obj.GetType().Name} on {value} points");
        }
        public void Repair(int value)
        {
            Health += value;
            Program.Log?.Invoke(this, $"Repaired on {value} points");
        }
    }
}
