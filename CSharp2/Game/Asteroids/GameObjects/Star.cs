﻿using GameEngineLibraryProject;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    class Star : BaseGameObject
    {
        public static Image Image { get; set; }

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Program.Log?.Invoke(this, "Created");
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);

            Program.Log?.Invoke(this, "Drawn");
        }
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0) pos.X = Game.Width + 20;

            Program.Log?.Invoke(this, "Updated");
        }
    }
}