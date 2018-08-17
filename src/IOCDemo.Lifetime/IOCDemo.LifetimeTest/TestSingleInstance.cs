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
    public class TestSingleInstance
    {
        [TestMethod]
        public void TestMethod()
        {
            SingleInstance singleInstance = new SingleInstance();

            var container = singleInstance.Init();
            var hashCodes = singleInstance.Resolve(container);

            //筛选不同的元素
            var unique = hashCodes.GroupBy(i => i)
                .Where(g => g.Count() == 1)
                .Select(g => g.ElementAt(0));

            Assert.AreEqual(0, unique.Count());
        }
    }
}
