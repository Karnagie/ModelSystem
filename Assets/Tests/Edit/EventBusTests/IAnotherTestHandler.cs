using Core.BusEvents;

namespace Tests.Edit.EventBusTests
{
    public interface IAnotherTestHandler : IGlobalSubscriber
    {
        void SetInt(int value);
    }
}