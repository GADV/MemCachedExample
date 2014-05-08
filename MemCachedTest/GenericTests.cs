using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemCached;

namespace MemCachedTest
{
    [TestClass]
    public class GenericTests
    {
        [TestMethod]
        public void OldestMessagesAreEvicted()
        {
            const int size = 5;
            var mCache = new DefaultMemCached(size);
            for (var i = 1; i <= size + 2; ++i)
            {
                mCache.Set("K" + i, i.ToString());
            }

            Assert.IsNull(mCache.Get("K1"));
            Assert.IsNull(mCache.Get("K2"));
            Assert.IsNotNull(mCache.Get("K3"));
        }

        [TestMethod]
        public void GettingAKeyChangesItsPriority()
        {
            const int size = 5;
            var mCache = new DefaultMemCached(size);
            for (var i = 1; i <= size; ++i)
            {
                mCache.Set("K" + i, i.ToString());
            }
            mCache.Get("K1");
            mCache.Set("K6", "6");
            mCache.Set("K7", "7");

            Assert.IsNotNull(mCache.Get("K1"));
            Assert.IsNull(mCache.Get("K2"));
            Assert.IsNull(mCache.Get("K3"));
            Assert.IsNotNull(mCache.Get("K4"));
        }

        [TestMethod]
        public void SettingAKeyChangesItsPriority()
        {
            const int size = 5;
            var mCache = new DefaultMemCached(size);
            for (var i = 1; i <= size; ++i)
            {
                mCache.Set("K" + i, i.ToString());
            }
            mCache.Set("K1", "123");
            mCache.Set("K6", "6");
            mCache.Set("K7", "7");

            var k1Val = mCache.Get("K1");
            Assert.IsNotNull(k1Val);
            Assert.AreEqual("123", k1Val);

            Assert.IsNull(mCache.Get("K2"));
            Assert.IsNull(mCache.Get("K3"));
            Assert.IsNotNull(mCache.Get("K4"));
        }
    }
}
