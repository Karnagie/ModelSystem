using GameModels.ObstacleEssence;
using MetaGame.GameEssence;
using Presenters.Types;
using UnityEngine;

namespace Presenters.ObstacleEssence
{
    public class ObstaclePoolPresenter : Presenter
    {
        [SerializeField] private Transform[] _obstacles;
        public override void Init(Game game)
        {
            _model = new ObstaclePool(transform, name, _obstacles);
        }
    }
}