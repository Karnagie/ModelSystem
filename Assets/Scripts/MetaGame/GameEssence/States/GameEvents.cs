using Core.StateMachine;

namespace MetaGame.GameEssence.States
{
    public static class GameEvents
    {
        public static readonly Event Run = new Event("run");
        public static readonly Event Pause = new Event("pause");
    }
}