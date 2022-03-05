
using Assets.Tests;
using UnityEngine;

namespace Tests.Edit.TestObjectFactory
{
    public class TestClass0 : MonoBehaviour
    {
        [TestField]
        private int _x;

        public int Get()
        {
            return _x;
        }
    }
    public class TestClass1 : MonoBehaviour
    {
        [TestField(Name = "x")]
        private int _x;
        [TestField(Name = "y")]
        private int _y;

        public int GetSumm()
        {
            return _x+_y;
        }
    }
    
    public class TestScriptableObject : ScriptableObject
    {
        [TestField(Name = "a")]
        private float _a;
        [TestField(Name = "b")]
        private float _b;

        public float GetDifference()
        {
            return _a - _b;
        }
    }
    
    public class ClassWithScriptableObject : MonoBehaviour
    {
        [TestField]
        private TestScriptableObject _calculator;

        public float GetDifference()
        {
            return _calculator.GetDifference();
        }
    }
}
