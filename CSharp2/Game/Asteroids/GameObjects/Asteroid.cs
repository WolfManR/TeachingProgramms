using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Asteroid : BaseGameObject, ICollision, IResetPos, IEnemyDestroyed, IDamagedObject
    {
        public Image Image { get; set; }
        public ILightWeightCollisionObject CollisionObject { get; }
        public int RecordPoints { get; }
        public int Health { get; private set; }
        public int Damage { get; }
        public int BaseHealth { get; }
        public bool IsDestroyed { get; private set; } = false;

        public Asteroid(Point pos, Point dir, Size size, int recordPoints, int health, int damage) : base(pos, dir, size)
        {
            this.CollisionObject = new LightWeightRectangleCollision(this);
            this.Health = health;
            this.BaseHealth = health;
            this.Damage = damage;
            this.RecordPoints = recordPoints;

            Program.Log?.Invoke(this, "Created");
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);

            Program.Log?.Invoke(this, "Drawn");
        }
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0) pos.X = Game.Width + 20;

            Program.Log?.Invoke(this, "Updated");
        }
        public void ResetPos()
        {
            pos.X = Game.Width;

            Program.Log?.Invoke(this, "Reset position");
        }

        public void Damaged(object obj,int value)
        {
            if (Health > 0 && Health - value > 0) Health -= value;
            else
            {
                (obj as Player)?.RecordUp(RecordPoints);
                //Health = BaseHealth;
                //ResetPos();
                IsDestroyed = true;
            }

            Program.Log?.Invoke(this, $"Damaged by {obj.GetType().Name} on {value} points");
        }
    }
}
