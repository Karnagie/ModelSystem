using NUnit.Framework;
using Tests.Edit.TestObjectFactory;

namespace Tests.Edit.TestObjectTests
{
    public class TestTestObject
    {
        private TestObject<TestClass0> testClassObject;
        private TestClass0 testClass_0;

        private TestObject<TestClass1> testObject1;
        private TestClass1 testClass1;
        
        private TestObject<TestScriptableObject> testScriptableObject;
        private TestScriptableObject testScriptable;
        
        private TestObject<ClassWithScriptableObject> testClassWithScriptableObject;
        private TestObject<TestScriptableObject> scriptableObject;
        private ClassWithScriptableObject testClassWithScriptable;


        [SetUp]
        public void SetUp()
        {
            testClassObject = new TestObject<TestClass0>();
            testClass_0 = testClassObject.Get();

            testObject1 = new TestObject<TestClass1>();
            testClass1 = testObject1.Get();
            
            testScriptableObject = new TestObject<TestScriptableObject>();
            testScriptable = testScriptableObject.Get();
            
            testClassWithScriptableObject = new TestObject<ClassWithScriptableObject>();
            scriptableObject = new TestObject<TestScriptableObject>();
            testClassWithScriptable = testClassWithScriptableObject.Get();
        }

        [Test]
        public void TestClass_Set1_Get1()
        {
            testClassObject.Set(1);

            Assert.AreEqual(1, testClass_0.Get());
        }

        [Test]
        public void TestClass1_Set1_GetSumm1()
        {
            testObject1.Set(1, "x");

            Assert.AreEqual(1, testClass1.GetSumm());
        }
        
        [Test]
        public void TestClass1_Set1AndSet2_Get3()
        {
            testObject1.Set(1, "x");
            testObject1.Set(2, "y");

            Assert.AreEqual(3, testClass1.GetSumm());
        }
        
        [Test]
        public void TestScriptableObject_SetA5_Get5()
        {
            testScriptableObject.Set(5f, "a");

            Assert.AreEqual(5f, testScriptable.GetDifference());
        }
        
        [Test]
        public void TestScriptableObject_SetA5andB5_Get0()
        {
            testScriptableObject.Set(5f, "a");
            testScriptableObject.Set(5f, "b");

            Assert.AreEqual(0f, testScriptable.GetDifference());
        }
        
        [Test]
        public void TestClassWithScriptableObject_SetA15andB5_Get10()
        {
            testClassWithScriptableObject.Set(scriptableObject.Get());
            scriptableObject.Set(15f, "a");
            scriptableObject.Set(5f, "b");

            Assert.AreEqual(10f, testClassWithScriptableObject.Get().GetDifference());
        }
    }
}
