using System.Collections.Generic;
using Core.StateMachine;
using MetaGame.Architecture.Models;
using MetaGame.GameEssence.States;

namespace MetaGame.GameEssence
{
    public class GameStateMachine : AutomatonBase<IGameState>, IGameState
    {
        public GameStateMachine(List<IModel> models)
        {
            IGameState run = new RunState<GameStateMachine>(this, this, models);
            IGameState pause = new PauseState<GameStateMachine>(this, this);
            
            AddEdge(run, GameEvents.Pause, pause);
            AddEdge(pause, GameEvents.Run, run);
            
            _state = pause;
        }
        
        public void Update(float deltaTime)
        {
            _state.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            _state.FixedUpdate(deltaTime);
        }

        public void End()
        {
            _state.End();
        }

        public void Start()
        {
            _state.Start();
        }
    }
}