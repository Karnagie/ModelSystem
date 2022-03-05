namespace Core.StateMachine
{
    public interface IState
    {
        void End();
        void Start();
    }
}