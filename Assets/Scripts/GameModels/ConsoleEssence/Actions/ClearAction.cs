using Core.BusEvents;
using Core.BusEvents.Handlers;
using GameModels.ConsoleEssence.ConsoleUiEssence;
using MetaGame.Actions;

namespace GameModels.ConsoleEssence.Actions
{
    public class ClearAction : GameAction<GameActionRunner>
    {
        private readonly ConsoleUi _ui;
        
        public ClearAction(ConsoleUi ui)
        {
            _ui = ui;
        }

        protected override void Prepare(GameActionRunner runner)
        {
            
        }

        protected override void Perform()
        {
            _ui.Clear();
        }

        protected override void Log()
        {
            EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException("Console was cleared"));
        }
    }
}