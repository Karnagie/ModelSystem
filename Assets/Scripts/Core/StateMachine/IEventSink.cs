namespace Core.StateMachine
{
    public interface IEventSink
    {
        void CastEvent(Event e);
    }
}