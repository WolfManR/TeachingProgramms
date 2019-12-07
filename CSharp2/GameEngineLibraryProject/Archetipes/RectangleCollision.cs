using System;
using System.Drawing;

namespace GameEngineLibraryProject.Archetipes
{
    public class RectangleCollision : ICollisionObject
    {
        private Rectangle collisionRect;

        public event EventHandler<object> Intersected;

        public object CollisionObj => collisionRect;
        public ISharedGameObjectData Parent { get; set; }

        public RectangleCollision(ISharedGameObjectData parent)
        {
            this.Parent = parent;
            this.collisionRect = new Rectangle(parent.Pos, parent.Size);
        }
        public bool Collision(ICollision obj)
        {
            CollisionPosUpdate(Parent.Pos);
            obj.CollisionObject.CollisionPosUpdate(obj.CollisionObject.Parent.Pos);
            bool check = ((Rectangle)obj.CollisionObject.CollisionObj).IntersectsWith((Rectangle)CollisionObj);
            if (check) Intersected?.Invoke(Parent, obj);
            return check;
        }

        public void CollisionPosUpdate(object newPos)
        {
            collisionRect.Location = (Point)newPos;
        }
    }
}
