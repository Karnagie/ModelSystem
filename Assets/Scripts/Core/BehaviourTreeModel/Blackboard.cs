using System;
using System.Collections.Generic;

namespace Core.BehaviourTreeModel
{
    [System.Serializable]
    public abstract class Blackboard
    {
        public abstract Dictionary<string, Func<Node.State>> objects { get; set; }
    }
}