using System.Collections.Generic;
using PriorityQueue;

namespace MemCached
{
    // Basic implementation
    //
    public class DefaultMemCached : IMemCached
    {
        private class CacheNode
        {
            public string Value;
            public PQNode PriorityNode;
        }

        private readonly int _maxNumElements;
        private readonly Dictionary<string, CacheNode> _memCache = new Dictionary<string, CacheNode>();
        
        // TODO: use Dependency Injection to choose between different implementations of IPQueue
        private readonly IPQueue _priorityQueue = new PQueue();

        public DefaultMemCached(int maxNum)
        {
            _maxNumElements = maxNum;
        }

        public string Get(string key)
        {
            if (!_memCache.ContainsKey(key))
            {
                return null;
            }
            var cacheNode = _memCache[key];
            _priorityQueue.IncreasePriority(cacheNode.PriorityNode);
            return cacheNode.Value;
        }

        public void Set(string key, string value)
        {
            if ((!_memCache.ContainsKey(key)) && (_memCache.Count == _maxNumElements))
            {
                Evict();
            }
            PQNode pNode = null;
            if (!_memCache.ContainsKey(key))
            {
                pNode = _priorityQueue.Insert(key);
            }
            else
            {
                pNode = _memCache[key].PriorityNode;
                _priorityQueue.IncreasePriority(pNode);
            }
            _memCache[key] = new CacheNode { Value = value, PriorityNode = pNode };
        }

        public void Delete(string key)
        {
            if (!_memCache.ContainsKey(key))
            {
                return;
            }

            var cacheNode = _memCache[key];
            _priorityQueue.Remove(cacheNode.PriorityNode);
            _memCache.Remove(key);
        }


        public void Evict()
        {
            var pNode = _priorityQueue.Extract();
            _memCache.Remove(pNode.Key);
        }
    }
}
