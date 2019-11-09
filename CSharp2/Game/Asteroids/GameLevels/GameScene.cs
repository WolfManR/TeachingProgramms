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
            if(Bullets!= null) foreach (Bullet obj in Bullets) obj.Draw();
            Game.buffer.Render();
        }

        public override void Update()
        {
            foreach (GameObject obj in BackGroundObjects) obj.Update();
            foreach (GameObject obj in CollisionsObjects)
            {
                obj.Update();
                if (Bullets != null)
                {
                    foreach (var bullet in Bullets)
                    {
                        if (bullet.CollisionObject.Collision(obj as ICollision))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            bullet.Player.AddRecord(1);
                            bullet.ResetPos();
                            (obj as IResetPos)?.ResetPos();
                        }
                        bullet.Update();
                    }
                }
            }
        }
    }
}
