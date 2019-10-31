using GameProject.GameObjects;
using System.Collections.Generic;
using System.Drawing;

namespace GameProject.Asteroids.GameLevels
{
    public class Level1: GameEngine.Scene
    {
        public override void Load()
        {
            Objects = new List<GameObject>();
            for (int i = 0; i < 15; i++)
                Objects.Add(new GameObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20)));
            Star.Image = Image.FromFile(@"Assets/star.png");
            for (int i = 15; i < 30; i++)
                Objects.Add(new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20)));
        }
    }
}
