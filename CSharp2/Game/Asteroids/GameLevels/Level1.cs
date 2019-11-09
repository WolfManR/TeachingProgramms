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
        public override void Load()
        {
            BackGroundObjects = new List<GameObject>();
            CollisionsObjects = new List<GameObject>();
            GenerateBackground();
            GenerateCollisionObjects();
            PlayerStartPosition = new List<Point>
            {
                new Point(0, Game.Height / 2)
            };

        }
        
        void GenerateBackground()
        {
            Star.Image = Image.FromFile(@"Assets/star.png");
            for (int i = 0; i < 400; i++)
                BackGroundObjects.Add(new Star(new Point(r.Next(40,Game.Width),r.Next(0,Game.Height)), new Point(-(15 - r.Next(2,8)), 0), new Size(Star.Image.Width, Star.Image.Height)));
        }

        void GenerateCollisionObjects()
        {
            for (int i = 0; i < 15; i++)
            {
                Image image = Image.FromFile($@"Assets/Asteroid{r.Next(1, 3)}.png");
                Asteroid asteroid = new Asteroid(new Point(r.Next(380, Game.Width), r.Next(70, Game.Height-120)), new Point(-(15 - r.Next(2, 4)), 0), new Size(image.Width, image.Height))
                {
                    Image = image
                };
                CollisionsObjects.Add(asteroid);

            }
        }
    }
}
