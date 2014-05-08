using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueue;

namespace PriorityQueueTest
{
    [TestClass]
    public class GenericTests
    {
        [TestMethod]
        public void NodesAreExtractedInOrderOfLowerPriority1()
        {
            const int numOfElements = 10;
            var pQueue = CreatePriorityQueue("A", numOfElements);
            for (var i = 0; i < numOfElements; ++i)
            {
                var node = pQueue.Extract();
                var value = int.Parse(node.Key.Split(':')[1]);
                Assert.AreEqual(i + 1, value);
            }

            Assert.IsTrue(pQueue.IsEmpty());
        }

        [TestMethod]
        public void NodesAreExtractedInOrderOfLowerPriority2()
        {
            var pQueue = new PQueue();
            var node1 = pQueue.Insert("A:11");
            var node2 = pQueue.Insert("A:12");
            var node3 = pQueue.Insert("A:13");

            pQueue.IncreasePriority(node1);
            var extractedNodeA = pQueue.Extract();
            Assert.AreEqual(node2, extractedNodeA);

            pQueue.IncreasePriority(node3);
            var extractedNodeB = pQueue.Extract();
            Assert.AreEqual(node1, extractedNodeB);
        }

        [TestMethod]
        public void CanRemoveSpecificNode()
        {
            var pQueue = new PQueue();
            var node1 = pQueue.Insert("A:11");
            var node2 = pQueue.Insert("A:12");
            var node3 = pQueue.Insert("A:13");

            pQueue.Remove(node2);

            var extractedNodeA = pQueue.Extract();
            Assert.AreEqual(node1, extractedNodeA);

            var extractedNodeB = pQueue.Extract();
            Assert.AreEqual(node3, extractedNodeB);

            Assert.IsTrue(pQueue.IsEmpty());
        }

        private static PQueue CreatePriorityQueue(string baseKey, int numOfElements)
        {
            var pQueue = new PQueue();

            for (var i = 0; i < numOfElements; ++i)
            {
                pQueue.Insert(baseKey + ":" + (i + 1).ToString());
            }

            return pQueue;
        }
    }
}
