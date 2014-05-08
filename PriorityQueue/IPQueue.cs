namespace PriorityQueue
{
    public interface IPQueue
    {
        PQNode Insert(string key);
        PQNode Extract();
        void Remove(PQNode node);
        void IncreasePriority(PQNode node);
        bool IsEmpty();
    }
}
