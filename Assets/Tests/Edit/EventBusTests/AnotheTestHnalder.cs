using Core.BusEvents;

namespace Tests.Edit.EventBusTests
{
    public class AnotheTestHnalder : IAnotherTestHandler
    {
        public int testInt = 0;
        public void Subscribe()
        {
            EventBus.Subscribe(this);
        }

        public void SetInt(int value)
        {
            testInt = value;
        }
    }
}