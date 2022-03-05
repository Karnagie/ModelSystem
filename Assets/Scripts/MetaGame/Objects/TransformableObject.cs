using MetaGame.Architecture.Models;
using UnityEngine;

namespace MetaGame.Objects
{
    public abstract class TransformableObject : IModel
    {
        protected Transform _transform;

        public string Name { get; private set; }

        protected TransformableObject(Transform transform, string name)
        {
            _transform = transform;
            Name = name;
        }

        public abstract void Tick(float deltaTime);

        public abstract void FixedTick(float deltaTime);
    }
}