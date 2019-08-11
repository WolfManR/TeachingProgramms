using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainProject.Code
{
    public class Asteroid
    {
        Vector2 Pos, Dir;
        Color color=Color.White;
        public Texture2D Texture { get; set; }

        public Asteroid(Vector2 pos,Vector2 dir)
        {
            Pos = pos;
            Dir = dir;
        }
    }
}
