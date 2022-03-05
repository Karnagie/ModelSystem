namespace Core.StateMachine
{
    public class Event
    {
        private readonly string _name;

        public Event(string name)
        {
            _name = name;
        }

        public string GetName() => _name;
    }
}