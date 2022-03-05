using Core.BusEvents;

namespace Tests.Edit.EventBusTests
{
    public class TestHandler : ITestHandler
    {
        public string answer = "";

        public void Subscribe()
        {
            EventBus.Subscribe(this);
        }
        
        public void SetAnswer(string message)
        {
            answer = message;
        }
    }
}