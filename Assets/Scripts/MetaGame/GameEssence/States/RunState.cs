using System.Collections.Generic;
using Core.StateMachine;
using MetaGame.Architecture.Models;

namespace MetaGame.GameEssence.States
{
    public class RunState<TAutomaton> : StateBase<TAutomaton>, IGameState
    {
        private List<IModel> _models;
        
        public RunState(TAutomaton autamaton, IEventSink eventSink, List<IModel> models) : base(autamaton, eventSink)
        {
            _models = models;
        }
        
        public void Update(float deltaTime)
        {
            foreach (var model in _models)
            {
                model.Tick(deltaTime);
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            foreach (var model in _models)
            {
                model.FixedTick(deltaTime);
            }
        }

        public void End()
        {
            
        }

        public void Start()
        {
            
        }
    }
}