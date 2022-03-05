namespace Core.StateMachine
{
    public abstract class StateBase<TA>
    {
        protected readonly TA _autamaton;
        protected readonly IEventSink _eventSink;

        public StateBase(TA autamaton, IEventSink eventSink)
        {
            _autamaton = autamaton;
            _eventSink = eventSink;
        }

        protected void CastEvent(Event e)
        {
            _eventSink.CastEvent(e);
        }
    }
}