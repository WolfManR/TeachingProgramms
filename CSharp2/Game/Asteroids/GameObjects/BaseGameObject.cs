using GameEngineLibraryProject;
using GameEngineLibraryProject.Exceptions;
using GameEngineLibraryProject.Archetipes;
using System.Drawing;

namespace GameProject.Asteroids.GameObjects
{
    public abstract class BaseGameObject : GameObject
    {
        protected BaseGameObject(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            if (pos.X > Game.Width + 400 || pos.X < -200 || dir.X > 100 || dir.Y > 100 || dir.X < -100 || dir.Y < -100 || size.Width < 0 || size.Width > Game.Width || size.Height < 0 || size.Height > Game.Height)
                throw new GameObjectException("Wrong Parameters");
        }
    }
}
