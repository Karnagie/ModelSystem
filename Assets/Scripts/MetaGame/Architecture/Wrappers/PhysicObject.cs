using MetaGame.Objects;
using UnityEngine;

namespace MetaGame.Architecture.Wrappers
{
    public abstract class PhysicObject : TransformableObject
    {
        protected ModelCollider _collider;
        
        protected PhysicObject(Transform transform, ModelCollider collider, string name) : base(transform, name)
        {
            _collider = collider;
        }
    }
}