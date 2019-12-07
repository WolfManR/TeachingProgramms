using GameEngineLibraryProject;
using GameEngineLibraryProject.Archetipes;
using GameProject.Asteroids.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameProject.Asteroids.GameLevels
{
    public class Level1 : GameScene
    {
        readonly Random r = new Random();
        public static int stars = 100;
        public static int asteroids = 6;
        public static int heals=2;
        public override void Load()
        {
            BackGroundObjects = new List<GameObject>();
            CollisionsObjects = new List<GameObject>();
            GenerateBackground();
            GenerateCollisionObjects();
            Bullets = new List<Bullet>();
            PlayerStartPosition = new List<Point>
            {
                new Point(0, Game.Height / 2)
            };
            UpdateCollisionObjects += UpdateCollision;
            Program.Log?.Invoke(this, "Loaded");
        }

        void GenerateBackground()
        {
            Star.Image = Image.FromFile(@"Assets/star.png");
            for (int i = 0; i < stars; i++)
                BackGroundObjects.Add(new Star(new Point(r.Next(40, Game.Width), r.Next(0, Game.Height)), new Point(-(15 - r.Next(2, 8)), 0), new Size(Star.Image.Width, Star.Image.Height)));

            Program.Log?.Invoke(this, "Background Generated");
        }
        void GenerateCollisionObjects()
        {
            GenerateAsteroids(asteroids);
            GenerateHeals(heals);
            

            Program.Log?.Invoke(this, "Collision Objects Generated");
        }
        void GenerateAsteroids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Image image = Image.FromFile($@"Assets/Asteroid{r.Next(1, 3)}.png");
                var asteroid = new Asteroid
                               (
                                   new Point(Game.Width +image.Width + r.Next(40,300), r.Next(70, Game.Height - 120)),
                                   new Point(-(15 - r.Next(2, 10)), 0),
                                   new Size(image.Width, image.Height),
                                   3,
                                   14,
                                   18
                               )
                {
                    Image = image
                };
                CollisionsObjects.Add(asteroid);
            }

            Program.Log?.Invoke(this, "Asteroids Objects Generated");
        }
        void GenerateHeals(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Image image = Image.FromFile($@"Assets/Heal.png");
                var heal = new Heal
                           (
                               new Point(r.Next(380, Game.Width), r.Next(70, Game.Height - 120)),
                               new Point(-(15 - r.Next(2, 4)), 0),
                               new Size(image.Width, image.Height),
                               30
                           )
                {
                    Image = image
                };
                CollisionsObjects.Add(heal);
            }

            Program.Log?.Invoke(this, "Heals Objects Generated");
        }

        void UpdateCollision()
        {
            bool IsAsteroidsExist = false;
            for (int col = 0; col < CollisionsObjects.Count; col++)
            {
                CollisionsObjects[col].Update();
                switch (CollisionsObjects[col])
                {
                    case IDamagedObject d:
                        if (Bullets != null)
                        {
                            for (int bul = 0; bul < Bullets.Count; bul++)
                            {
                                if ((Bullets[bul].CollisionObject as ICollisionObject).Collision(d as ICollision))
                                {
                                    System.Media.SystemSounds.Hand.Play();
                                    if (Bullets[bul].IsDestroyed) Bullets.RemoveAt(bul--);
                                }
                            }
                        }
                        if (((Player.ControlledObject as ICollision).CollisionObject as ICollisionObject).Collision(d as ICollision))
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                        }
                        if (CollisionsObjects[col] is Asteroid a)
                        {
                            IsAsteroidsExist = true;
                            if (a.IsDestroyed) CollisionsObjects.RemoveAt(col--);
                        }
                        break;
                    case IBonusObject b:
                        if (((Player.ControlledObject as ICollision).CollisionObject as ICollisionObject).Collision(b as ICollision))
                        {
                            System.Media.SystemSounds.Asterisk.Play();
                        }
                        break;
                    default:
                        break;
                }
            }
            if (IsAsteroidsExist == false)
            {
                GenerateAsteroids(++asteroids);
            }

            foreach (var item in Bullets)
            {
                item.Update();
            }
        }
    }
}
