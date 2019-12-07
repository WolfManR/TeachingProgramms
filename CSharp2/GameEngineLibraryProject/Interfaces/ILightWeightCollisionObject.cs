namespace GameEngineLibraryProject
{
    public interface ILightWeightCollisionObject
    {
        object CollisionObj { get; }
        ISharedGameObjectData Parent { get; set; }
        void CollisionPosUpdate(object newPos);
    }
}
