using System;
using MetaGame.Actions;
using UnityEngine;

namespace MetaGame.Architecture.Wrappers
{
    [RequireComponent(typeof(Collider))]
    public class ModelCollider : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        public event Action<Collider> OnEnter;
        public event Action<ModelGameAction> OnTrigger;
        
        private void OnTriggerEnter(Collider col)
        {
            OnEnter?.Invoke(col);
        }
        
        public void Trigger(ModelGameAction hit)
        {
            OnTrigger?.Invoke(hit);
        }
        
        private void OnDestroy()
        {
            OnEnter = null;
        }
    }
}