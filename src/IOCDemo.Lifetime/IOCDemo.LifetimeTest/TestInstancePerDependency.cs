using System;
using System.Linq;
using IOCDemo.Lifetime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IOCDemo.LifetimeTest
{
    [TestClass]
    public class TestInstancePerDependency
    {
        [TestMethod]
        public void TestMethod()
        {
            InstancePerDependency instancePer = new InstancePerDependency();

            var container = instancePer.Init();

            var hashCodes = instancePer.Resolve(container);

            //筛选不同的元素
            var unique = hashCodes.GroupBy(i => i)
                .Where(g => g.Count() == 1)
                .Select(g => g.ElementAt(0));

            Assert.AreEqual(hashCodes.Count(), unique.Count());
        }
    }
}
