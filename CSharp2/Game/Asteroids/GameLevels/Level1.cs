using GameProject.Asteroids.GameObjects;
using GameProject.GameEngine;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameProject.Asteroids.GameLevels
{
    public class Level1 : Scene
    {
        readonly Random r = new Random();
        public override void Load()
        {
            Objects = new List<GameObject>();
            CollisionsObjects = new List<GameObject>();
            GenerateBackground();
            GenerateCollisionObjects();
            GeneratePlayer();

        }

        void GenerateBackground()
        {
            Star.Image = Image.FromFile(@"Assets/star.png");
            for (int i = 0; i < 400; i++)
                Objects.Add(new Star(new Point(r.Next(40,Game.Width),r.Next(0,Game.Height)), new Point(-(15 - r.Next(2,8)), 0), new Size(Star.Image.Width, Star.Image.Height)));
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

        void GeneratePlayer()
        {
            Image image = Image.FromFile(@"Assets/ship.png");
            Player = new Player(new Point(0, Game.Height / 2), new Point(), new Size(image.Width, image.Height))
            {
                Image = image
            };
            Player.Weapon = new Weapon(new Bullet(Player.WeaponPos, new Point(10, 0), new Size(4, 2)));
        }
    }
}
