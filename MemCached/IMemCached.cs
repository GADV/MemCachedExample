namespace MemCached
{
    public interface IMemCached
    {
        string Get(string key);
        void Set(string key, string value);
        void Delete(string key);
        void Evict();
    }
}
