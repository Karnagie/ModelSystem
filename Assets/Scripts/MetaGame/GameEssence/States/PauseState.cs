using Core.StateMachine;
using UnityEngine;

namespace MetaGame.GameEssence.States
{
    public class PauseState<TAutomaton> : StateBase<TAutomaton>, IGameState
    {
        public PauseState(TAutomaton autamaton, IEventSink eventSink) : base(autamaton, eventSink)
        {
            
        }
        
        public void Update(float deltaTime)
        {
            
        }

        public void FixedUpdate(float deltaTime)
        {
            
        }

        public void End()
        {
            Time.timeScale = 1;
        }

        public void Start()
        {
            Time.timeScale = 0;
        }
    }
}