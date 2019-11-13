using System;

namespace GameEngineLibraryProject
{
    public interface ICollisionObject:ILightWeightCollisionObject
    {
        event EventHandler<object> Intersected;
        bool Collision(ICollision obj);
    }
}
