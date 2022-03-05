using System;
using System.Collections.Generic;
using Core.BehaviourTreeModel;
using UnityEngine;

namespace GameModels.BehaviourTreeEssence
{
    public class TestBlackboard : Blackboard
    {
        private Dictionary<string, Func<Node.State>> _actions = new Dictionary<string, Func<Node.State>>()
        {
            {"test_0", () => {Debug.Log("Test0");
                return Node.State.Success;
            } } ,
            {"test_1", () => {Debug.Log("Test1");
                return Node.State.Success;
            } } 
        };
        public override Dictionary<string, Func<Node.State>> objects { get => _actions; set => _actions = value; }
    }
}