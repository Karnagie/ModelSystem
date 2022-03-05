using MetaGame.Architecture.Models;
using MetaGame.GameEssence;

namespace MetaGame.Architecture.Presenters
{
    public interface IPresenter
    {
        void Init(Game game);
        
        IModel GetModel();
    }
}