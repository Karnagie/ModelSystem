using MetaGame.Actions;
using MetaGame.GameEssence;

namespace Presenters.Types
{
    public abstract class ActionPresenter : Presenter
    {
        private GameAction<GameActionRunner> _action;
        
        public override void Init(Game game)
        {
            _action = SetActionInternal(game);
            game.GameActionRunner.Execute(_action);
            Destroy(gameObject);
        }

        protected abstract GameAction<GameActionRunner> SetActionInternal(Game game);
    }
}