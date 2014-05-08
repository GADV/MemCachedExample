using MemCached;

namespace TestApp
{
    class Program
    {

        /**
         * TODO:
         * 
         *      - Introduce Unity and use Dependency Injection
         *      - Stress tests
         *      - Manage exceptions
         *      - Preallocate all the needed memoory at the startup (if possible)
         *      - Implement different versions and compare their performances
         * 
         */

        static void Main(string[] args)
        {
            IMemCached memCached = new DefaultMemCached(10);

            memCached.Set("A", "Apple");
            memCached.Set("B", "Bubble");
            memCached.Set("C", "Cat");

            memCached.Set("B", "Many Bubbles");
            memCached.Set("C", "A lot of Cats");

            System.Console.WriteLine("'B' is " + memCached.Get("B"));
            System.Console.WriteLine("'C' is " + memCached.Get("C"));
        }
    }
}
