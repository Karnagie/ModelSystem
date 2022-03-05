using Core.BehaviourTreeModel;
using MetaGame.Architecture.Models;

namespace GameModels.BehaviourTreeEssence
{
    public class TestBT : IModel
    {
        private BehaviourTree _tree;
        
        public TestBT(BehaviourTree tree)
        {
            _tree = tree;
        }

        public string Name { get; private set; } = "test tree";

        public void Tick(float deltaTime)
        {
            _tree.Update();
        }

        public void FixedTick(float deltaTime)
        {
            
        }
    }
}