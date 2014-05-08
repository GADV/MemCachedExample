using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueue;

namespace PriorityQueueTest
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void CanCreateAnInstanceOfPQueue()
        {
            var pQueue = new PQueue();
            Assert.IsNotNull(pQueue);
        }

        [TestMethod]
        public void InsertMethodReturnAProperObject()
        {
            var pQueue = new PQueue();
            string key = "theKey";
            var pNode = pQueue.Insert(key);

            Assert.IsNotNull(pNode);
            Assert.AreEqual(pNode.Key, key);
        }

        [TestMethod]
        public void ExtractMethodReturnAProperObject()
        {
            var pQueue = new PQueue();
            string key = "theKey";
            var createdNode = pQueue.Insert(key);
            var extractedNode = pQueue.Extract();

            Assert.IsNotNull(extractedNode);
            Assert.AreEqual(createdNode.Key, extractedNode.Key);
            Assert.AreEqual(createdNode.Priority, extractedNode.Priority);
        }

        [TestMethod]
        public void IncreasePriorityWorksWithOneObject()
        {
            var pQueue = new PQueue();
            string key = "theKey";
            var createdNode = pQueue.Insert(key);
            int originalPriority = createdNode.Priority;
            pQueue.IncreasePriority(createdNode);
            var extractedNode = pQueue.Extract();

            Assert.IsTrue(extractedNode.Priority > originalPriority);
        }
    }
}
