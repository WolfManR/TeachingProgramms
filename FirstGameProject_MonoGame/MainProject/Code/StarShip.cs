using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainProject
{
    public class StarShip
    {
        Vector2 Pos;
        Color color=Color.White;
        public int speed { get; set; } = 3;

        public static Texture2D Texture2D { get; set; }

        public StarShip(Vector2 pos)
        {
            Pos = pos;
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y -= speed;
        }

        public void Down()
        {
            if (Pos.Y < Asteroids.Height - Texture2D.Height) Pos.Y += speed;
        }


        public void Left()
        {
            if (Pos.X > 0) Pos.X -= speed;
        }

        public void Right()
        {
            if (Pos.X < Asteroids.Width - Texture2D.Width) Pos.X += speed;
        }

        public void Draw() => Asteroids.SpriteBatch.Draw(Texture2D, Pos, color);
    }

}
