using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.GameObjects
{
    class Star : GameObject
    {

        public static Image Image { get; set; }

        public Star() : base(new Point(0, 0), new Point(0, 0), new Size(0, 0))
        {

        }


        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0) dir.X = Game.Width + 20;
        }

        public override void Draw()
        {
            //Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawImage(Image, pos);

        }

    }
}
