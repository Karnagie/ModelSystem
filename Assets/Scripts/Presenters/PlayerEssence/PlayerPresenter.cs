using GameModels.PlayerEssence;
using MetaGame.Architecture.Wrappers;
using MetaGame.GameEssence;
using Presenters.Types;
using UnityEngine;

namespace Presenters.PlayerEssence
{
    public class PlayerPresenter : Presenter
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private PlayerGizmos _gizmos;
        [SerializeField] private AnimationCurve _jump;
        [SerializeField] private ModelCollider _collider;
        
        public override void Init(Game game)
        {
            _model = new Player(_transform, _collider, name, _gizmos, _jump);
        }
    }
}