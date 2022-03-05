using Core.BusEvents;

namespace MetaGame.Architecture.Presenters
{
    public interface IPresenterHandler : IGlobalSubscriber
    {
        void AddPresenter(IPresenter presenter);
    }
}