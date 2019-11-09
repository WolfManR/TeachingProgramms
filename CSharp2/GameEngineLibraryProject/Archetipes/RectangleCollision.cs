using System.Drawing;

namespace GameEngineLibraryProject.Archetipes
{
    public class RectangleCollision : ICollisionObject
    {
        private Rectangle collisionRect;
        public Rectangle CollisionRect => collisionRect;
        public ISharedGameObjectData Parent { get; set; }

        public RectangleCollision(ISharedGameObjectData parent)
        {
            this.Parent = parent;
            this.collisionRect = new Rectangle(parent.Pos, parent.Size);
        }
        public bool Collision(ICollision obj)
        {
            if (Parent.Pos != collisionRect.Location) CollisionRectPosUpdate(Parent.Pos);
            return (obj.CollisionObject as RectangleCollision).CollisionRect.IntersectsWith(this.CollisionRect);
        }

        void CollisionRectPosUpdate(Point newPos)
        {
            if (collisionRect != null) collisionRect.Location = newPos;
        }
    }
}
