using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.Lifetime
{
    /// <summary>
    /// 对于一个服务每次请求都会返回一个唯一的实例
    /// </summary>
    public class InstancePerDependency
    {
        public IContainer Init()
        {
            var builder = new ContainerBuilder();
            // This...
            //builder.RegisterType<Worker>();
            // ...is the same as this:
            builder.RegisterType<Worker>().InstancePerDependency();

            IContainer container = builder.Build();
            return container;
        }

        public IEnumerable<int> Resolve(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                for (var i = 0; i < 5; i++)
                {
                    var woker = scope.Resolve<Worker>();
                    yield return woker.GetHashCode(); 
                }
            }
        }
    }
}
