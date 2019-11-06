using GameProject.Asteroids.GameObjects;
using GameProject.GameEngine;
using System.Collections.Generic;
using System.Drawing;

namespace GameProject.Asteroids.GameLevels
{
    public class Level1: Scene
    {
        public override void Load()
        {
            Objects = new List<GameObject>();
            
            
        }

        void GenerateBackground()
        {
            Star.Image = Image.FromFile(@"Assets/star.png");
            for (int i = 0; i < 15; i++)
                Objects.Add(new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20)));
        }

        void GenerateEnemies()
        {
            for (int i = 0; i < 15; i++)
                Objects.Add(new Asteroid(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20)));
        }

        void GeneratePlayer()
        {

        }
    }
}
