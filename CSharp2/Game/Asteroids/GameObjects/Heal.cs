using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public class Heal : BaseGameObject,ICollision,IResetPos,IBonusObject
    {
        readonly int healPoints;
        public Image Image { get; set; }
        public ILightWeightCollisionObject CollisionObject { get; }
        public Heal(Point pos, Point dir, Size size, int healPoints) : base(pos, dir, size)
        {
            this.CollisionObject = new LightWeightRectangleCollision(this);
            this.healPoints = healPoints;

            Program.Log?.Invoke(this, "Created");
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);

            Program.Log?.Invoke(this, "Drawn");
        }

        public void ResetPos()
        {
            pos.X = Game.Width;

            Program.Log?.Invoke(this, "Reset position");
        }

        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0) pos.X = Game.Width + 20;

            Program.Log?.Invoke(this, "Updated");
        }

        public void Bonus(object obj)
        {
            Ship ship = obj as Ship;
            if (ship.Health < ship.BaseHealth && ship.Health + healPoints < ship.BaseHealth) ship.Repair(healPoints);
            else if (ship.Health + healPoints > ship.BaseHealth) ship.Repair(ship.BaseHealth - ship.Health);
            ResetPos();

            Program.Log?.Invoke(this, $"Bonus given to {obj.GetType().Name}");
        }
    }
}
