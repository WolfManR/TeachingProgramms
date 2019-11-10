using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using GameProject.Asteroids.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameProject.Asteroids.GameLevels
{
    public abstract class GameScene : Scene
    {
        List<GameObject> collisionsObjects;
        public List<Point> PlayerStartPosition { get; set; }
        public List<Bullet> Bullets { get; set; }
        public List<GameObject> CollisionsObjects
        {
            get => collisionsObjects;
            set
            {
                foreach (var item in value)
                    if (!(item is ICollisionObject)) throw new ArgumentException("This collection support only ICollection objects");
                collisionsObjects = value;
            }
        }
        public Player Player { get; set; }

        public override void Draw()
        {
            Game.buffer.Graphics.Clear(Color.Black);
            foreach (GameObject obj in BackGroundObjects) obj.Draw();
            foreach (GameObject obj in CollisionsObjects) obj.Draw();
            Player.ControlledObject.Draw();
            Game.buffer.Graphics.DrawString($"Record: {Player.Record}", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 200, 10);
            Game.buffer.Graphics.DrawString($"Health: {(Player.ControlledObject as IDamagedObject).Health}", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 10, 10);
            if (Bullets!= null) foreach (Bullet obj in Bullets) obj.Draw();
            Game.buffer.Render();

            Program.Log?.Invoke(this, "Drawn");
        }

        public override void Update()
        {
            foreach (GameObject obj in BackGroundObjects) obj.Update();
            foreach (GameObject obj in CollisionsObjects)
            {
                obj.Update();
                switch (obj)
                {
                    case IDamagedObject d:
                        if (Bullets != null)
                        {
                            List<Bullet> destroyedBullets = new List<Bullet>();
                            foreach (var bullet in Bullets)
                            {
                                if ((bullet.CollisionObject as ICollisionObject).Collision(d as ICollision))
                                {
                                    System.Media.SystemSounds.Hand.Play();
                                    if (bullet.IsDestroyed) destroyedBullets.Add(bullet);
                                }
                            }
                            if (destroyedBullets != null) foreach (var bullet in destroyedBullets) Bullets.Remove(bullet);
                        }
                        if (((Player.ControlledObject as ICollision).CollisionObject as ICollisionObject).Collision(obj as ICollision))
                        {
                            System.Media.SystemSounds.Question.Play();
                        }
                        break;
                    case IBonusObject b:
                        if (((Player.ControlledObject as ICollision).CollisionObject as ICollisionObject).Collision(b as ICollision))
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                        break;
                    default:
                        break;
                }
                
                
            }
            foreach (var item in Bullets)
            {
                item.Update();
            }

            Program.Log?.Invoke(this, "Updated");
        }
    }
}
