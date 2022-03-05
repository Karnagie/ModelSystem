using MetaGame.Actions;
using UnityEngine;

namespace MetaGame.Architecture.Wrappers
{
    public abstract class AliveObject : PhysicObject, IActionRunner
    {
        protected float _health = 100;
        
        public float Health => _health;
        
        protected AliveObject(Transform transform, ModelCollider collider, string name) : base(transform, collider, name)
        {
            
        }

        public abstract void GetDamage(float value);
    }
}