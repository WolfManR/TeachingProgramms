using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MainProject
{
    public static class GameScene
    {
        public static int Width, Height;
        public static Random rnd = new Random();
        public static SpriteBatch SpriteBatch { get; set; }
        static Star[] stars;
        public static StarShip StarShip { get; set; }
        public static int GetIntRnd(int min, int max) => rnd.Next(min, max);
        public static void Init(SpriteBatch spriteBatch,int width,int height)
        {
            Width = width;
            Height = height;
            SpriteBatch = spriteBatch;
            stars = new Star[50];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Vector2(-rnd.Next(1, 10), 0));
            }
            StarShip = new StarShip(new Vector2(0, Height / 2 - 27));
        }
        public static void Draw()
        {
            foreach (Star star in stars)
            {
                star.Draw();
            }
            StarShip.Draw();
        }
        public static void Update()
        {
            foreach (Star star in stars)
            {
                star.Update();
            }
        }
    }
}
