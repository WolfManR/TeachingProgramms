using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainProject
{
    static class SplashScreen
    {
        public static Texture2D BackGround { get; set; }
        static int timeCounter = 0;
        static Color color;

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, Vector2.Zero, color);
        }

        public static void Update()
        {
            color = Color.FromNonPremultiplied(255, 255, 255, timeCounter % 256);
            timeCounter++;
        }
    }
}
