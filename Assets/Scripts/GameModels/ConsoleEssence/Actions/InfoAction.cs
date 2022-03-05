using System;
using Core.BusEvents;
using Core.BusEvents.Handlers;
using MetaGame.Actions;

namespace GameModels.ConsoleEssence.Actions
{
    public class InfoAction : GameAction<GameActionRunner>
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
                EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException("---Commands info:"));
                foreach (var info in ConsoleActions.Infos)
                {
                    EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException($"Command {info.name}: {info.info}"));
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