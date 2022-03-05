using MetaGame.Architecture.Models;
using MetaGame.Architecture.Presenters;
using MetaGame.GameEssence;
using UnityEngine;

namespace Presenters.Types
{
    public abstract class Presenter : MonoBehaviour, IStartPresenter
    {
        protected IModel _model;

        public abstract void Init(Game game);

        public IModel GetModel()
        {
            return _model;
        }
    }
}