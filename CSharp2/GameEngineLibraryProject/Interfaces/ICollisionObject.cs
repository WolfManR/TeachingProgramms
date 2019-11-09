using System.Drawing;

namespace GameEngineLibraryProject
{
    public interface ICollisionObject
    {
        ISharedGameObjectData Parent { get; set; }
        bool Collision(ICollision obj);
    }
}
