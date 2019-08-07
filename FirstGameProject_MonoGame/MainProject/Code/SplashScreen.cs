using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainProject
{
    static class SplashScreen
    {
        public static Texture2D BackGround { get; set; }
        static int timeCounter = 0;
        static Color color;
        public static SpriteFont Font { get; set; }
        static Vector2 TextPosition = new Vector2(200, 300);

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Font, "Астероиды", TextPosition, color);
        }

        public static void Update()
        {
            color = Color.FromNonPremultiplied(255, 255, 255, timeCounter % 256);
            timeCounter++;
        }
    }
}
