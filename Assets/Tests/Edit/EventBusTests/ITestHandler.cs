using Core.BusEvents;

namespace Tests.Edit.EventBusTests
{
    public interface ITestHandler : IGlobalSubscriber
    {
        void SetAnswer(string message);
    }
}