using System;
using System.Collections.Generic;
using Core.Exeptions;

namespace Core.StateMachine
{
    public class AutomatonBase<TState> : IEventSink where TState : IState
    {
        protected TState _state;

        private readonly Dictionary<TState, Dictionary<Event, TState>> _edges
            = new Dictionary<TState, Dictionary<Event, TState>>();

        protected void AddEdge(TState source, Event e, TState target)
        {
            Dictionary<Event, TState> row = new Dictionary<Event, TState>();
            
            if (!_edges.ContainsKey(source))
            {
                _edges.Add(source, row);
            }
            row = _edges[source];
            row.Add(e, target);
        }

        public void CastEvent(Event e)
        {
            try
            {
                _state.End();
                _state = _edges[_state][e];
                _state.Start();
            }
            catch (Exception exception)
            {
                throw new ConsoleException(exception.Message);
            }
        }
    }
}