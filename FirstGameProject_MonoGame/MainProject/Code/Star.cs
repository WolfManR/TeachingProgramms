using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainProject
{
    public class Star
    {
        Vector2 Pos;
        Vector2 Dir;
        Color color;

        public static Texture2D Texture2D { get; set; }

        public Star(Vector2 pos,Vector2 dir)
        {
            Pos = pos;
            Dir = dir;
        }

        public Star(Vector2 dir)
        {
            Dir = dir;
            RandomSet();
        }

        public void Update()
        {
            Pos += Dir;
            if (Pos.X<0)
            {
                RandomSet();
            }
        }

        public void RandomSet()
        {
            Pos = new Vector2
                (
                Asteroids.GetIntRnd(Asteroids.Width, Asteroids.Width + 300),
                Asteroids.GetIntRnd(0, Asteroids.Height)
                );
            color = Color.FromNonPremultiplied
                (
                Asteroids.GetIntRnd(0, 256),
                Asteroids.GetIntRnd(0, 256),
                Asteroids.GetIntRnd(0, 256),
                Asteroids.GetIntRnd(0, 256)
                );
        }

        public void Draw() => Asteroids.SpriteBatch.Draw(Texture2D, Pos, color);
    }
}
