using Core.BehaviourTreeModel.Nodes;

namespace MetaGame.BehaviourTreeNodes
{
    public class CustomActionNode : ActionNode
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            var state =blackboard.objects[customEventKey]?.Invoke();
            return (State) state;
        }
    }
}