using Core.BusEvents;
using NUnit.Framework;

namespace Tests.Edit.EventBusTests
{
    public class EventBusTests
    {
    
        [Test]
        public void SubscribeOneClassToEventBus()
        {
            var testClass = new TestHandler();
            
            testClass.Subscribe();

            Assert.AreEqual(EventBus.GetSubscribersTypes(testClass).Count, 1);
        }
        
        [Test]
        public void RaiseEventForOneSubscriber()
        {
            var testClass = new TestHandler();
            testClass.Subscribe();
            
            Assert.IsTrue(testClass.answer == "");

            EventBus.RaiseEvent((ITestHandler handler) => {handler.SetAnswer("raised");});

            Assert.AreEqual(testClass.answer, "raised");
        }
        
        [Test]
        public void RaiseEventForTwoSubscribers()
        {
            var testClass_0 = new TestHandler();
            var testClass_1 = new TestHandler();
            testClass_0.Subscribe();
            testClass_1.Subscribe();
            
            Assert.IsTrue(testClass_0.answer == "");
            Assert.IsTrue(testClass_1.answer == "");

            EventBus.RaiseEvent((ITestHandler handler) => {handler.SetAnswer("raised");});

            Assert.AreEqual(testClass_0.answer, "raised");
            Assert.AreEqual(testClass_1.answer, "raised");
        }
        
        [Test]
        public void RaiseEventForOnlyOneHandler()
        {
            var testClass_0 = new TestHandler();
            var testClass_1 = new AnotheTestHnalder();
            testClass_0.Subscribe();
            testClass_1.Subscribe();
            
            Assert.IsTrue(testClass_0.answer == "");
            Assert.IsTrue(testClass_1.testInt == 0);

            EventBus.RaiseEvent((ITestHandler handler) => {handler.SetAnswer("raised");});

            Assert.AreEqual(testClass_0.answer, "raised");
            Assert.AreEqual(testClass_1.testInt, 0);
        }
        
        [Test]
        public void RaiseEventForTwoDifferentHandlers()
        {
            var testClass_0 = new TestHandler();
            var testClass_1 = new AnotheTestHnalder();
            testClass_0.Subscribe();
            testClass_1.Subscribe();
            
            Assert.IsTrue(testClass_0.answer == "");
            Assert.IsTrue(testClass_1.testInt == 0);

            EventBus.RaiseEvent((ITestHandler handler) => {handler.SetAnswer("raised");});
            EventBus.RaiseEvent((IAnotherTestHandler handler) => {handler.SetInt(6);});

            Assert.AreEqual(testClass_0.answer, "raised");
            Assert.AreEqual(testClass_1.testInt, 6);
        }
    }
}
