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
        readonly int stars = 100;
        readonly int asteroids = 6;
        readonly int heals=2;
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
            for (int i = 0; i < asteroids; i++)
            {
                Image image = Image.FromFile($@"Assets/Asteroid{r.Next(1, 3)}.png");
                var asteroid = new Asteroid
                               (
                                   new Point(r.Next(380, Game.Width), r.Next(70, Game.Height - 120)),
                                   new Point(-(15 - r.Next(2, 4)), 0),
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
            for (int i = 0; i < heals; i++)
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

            Program.Log?.Invoke(this, "Collision Objects Generated");
        }
    }
}
