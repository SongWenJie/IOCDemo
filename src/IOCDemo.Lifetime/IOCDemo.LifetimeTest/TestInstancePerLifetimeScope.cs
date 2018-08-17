using IOCDemo.Lifetime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.LifetimeTest
{
    [TestClass]
    public class TestInstancePerLifetimeScope
    {
        [TestMethod]
        public void TestMethod()
        {
            InstancePerLifetimeScope instancePerLifetimeScope = new InstancePerLifetimeScope();

            var container = instancePerLifetimeScope.Init();
            var hashCodes = instancePerLifetimeScope.Resolve(container);

            //筛选相同的元素
            var unique = hashCodes.GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.ElementAt(0));

            Assert.AreEqual(2, unique.Count());
        }
    }
}
