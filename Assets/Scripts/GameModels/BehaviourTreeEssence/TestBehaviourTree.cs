using Core.BehaviourTreeModel;
using UnityEngine;

namespace GameModels.BehaviourTreeEssence
{
    [CreateAssetMenu()]
    public class TestBehaviourTree : BehaviourTree
    {
        private Blackboard _blackboard = new TestBlackboard();
        public override Blackboard blackboard { get => _blackboard; set => _blackboard = value; }
    }
}