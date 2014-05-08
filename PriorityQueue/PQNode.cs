namespace PriorityQueue
{
    public class PQNode
    {
        public PQNode(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }
        public int Priority { get; internal set; }
        
        // Storing the index preserves from using the ".IndexOf(...)" method that is O(n).
        internal int Index;
    }
}
