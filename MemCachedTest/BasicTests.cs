using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemCached;

namespace MemCachedTest
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void CanCreateAMemCachedInstance()
        {
            var mCache = new DefaultMemCached(10);
            
            Assert.IsNotNull(mCache);
        }

        [TestMethod]
        public void CanSetAndGetAnEntry()
        {
            var mCache = new DefaultMemCached(10);
            mCache.Set("X", "Y");

            Assert.AreEqual("Y", mCache.Get("X"));
            Assert.IsNull(mCache.Get("Y"));
        }

        [TestMethod]
        public void CanSetAnExistingEntry()
        {
            var mCache = new DefaultMemCached(10);
            mCache.Set("X", "Y");
            mCache.Set("X", "Z");

            Assert.AreEqual("Z", mCache.Get("X"));
        }

        [TestMethod]
        public void CanDeleteAnEntry()
        {
            var mCache = new DefaultMemCached(10);
            mCache.Set("X", "Y");
            
            Assert.IsNotNull(mCache.Get("X"));
            mCache.Delete("X");
            Assert.IsNull(mCache.Get("X"));
        }
    }
}
