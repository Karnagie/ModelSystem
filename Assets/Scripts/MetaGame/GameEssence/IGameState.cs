using Core.StateMachine;

namespace MetaGame.GameEssence
{
    public interface IGameState : IState
    {
        void Update(float deltaTime);
        void FixedUpdate(float deltaTime);
    }
}