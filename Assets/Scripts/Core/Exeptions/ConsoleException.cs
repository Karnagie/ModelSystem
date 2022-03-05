using System;
using Core.BusEvents;
using Core.BusEvents.Handlers;

namespace Core.Exeptions
{
    public class ConsoleException : Exception
    {
        public ConsoleException(string message) : base()
        {
            EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException(message));
        }
    }
}