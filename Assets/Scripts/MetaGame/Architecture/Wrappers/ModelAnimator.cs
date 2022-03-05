using UnityEngine;

namespace MetaGame.Architecture.Wrappers
{
    [RequireComponent(typeof(Animator))]
    public class ModelAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _aniamtor;

        public void Play(string stateName)
        {
            _aniamtor.Play(stateName);
        }
    }
}