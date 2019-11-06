using System.Drawing;

namespace GameProject.GameEngine
{
    public interface ICollision
    {
        bool Collision(ICollision obj);

        Rectangle CollisionRect { get; }
    }
}
