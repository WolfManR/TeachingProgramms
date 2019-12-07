using System.Drawing;

namespace GameEngineLibraryProject.Archetipes
{
    public class LightWeightRectangleCollision : ILightWeightCollisionObject
    {
        private Rectangle collisionRect;

        public object CollisionObj => collisionRect;
        public ISharedGameObjectData Parent { get; set; }

        public LightWeightRectangleCollision(ISharedGameObjectData parent)
        {
            this.Parent = parent;
            this.collisionRect = new Rectangle(parent.Pos, parent.Size);
        }

        public void CollisionPosUpdate(object newPos)
        {
            collisionRect.Location = (Point)newPos;
        }
    }
}
