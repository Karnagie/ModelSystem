using Core.BehaviourTreeModel;
using GameModels.BehaviourTreeEssence;
using MetaGame.GameEssence;
using Presenters.Types;
using UnityEngine;

namespace Presenters.BehaviourTreeEssence
{
    public class BehaviourTreePresenter : Presenter, IBehaviourTreeHandler
    {
        [SerializeField] private BehaviourTree _tree;
        
        private TestBT Tree
        {
            get => (TestBT)_model;
            set => _model = value;
        }

        public BehaviourTree BehaviourTree
        {
            get => _tree;
            set => _tree = value;
        }

        public override void Init(Game game)
        {
            var clone = _tree.Clone();
            clone.blackboard = new TestBlackboard();
            clone.Bind();
            _tree = clone as TestBehaviourTree;
            Tree = new TestBT(clone);
        }
    }
}