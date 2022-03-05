using System;
using Core.BusEvents;
using Core.BusEvents.Handlers;
using MetaGame.Actions;

namespace GameModels.ConsoleEssence.Actions
{
    public class ShowExamplesAction : GameAction<GameActionRunner>
    {
        protected override void Prepare(GameActionRunner runner)
        {
            
        }

        protected override void Perform()
        {
            
        }

        protected override void Log()
        {
            try
            {
                EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException("---Commands examples:"));
                foreach (var info in ConsoleActions.Infos)
                {
                    EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException($"Command {info.name}: {info.example}"));
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }
    }
}