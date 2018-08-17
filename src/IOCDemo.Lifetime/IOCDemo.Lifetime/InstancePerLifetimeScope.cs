using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.Lifetime
{
    /// <summary>
    /// 每个生命周期作用域一个实例(Instance Per Lifetime Scope)
    /// 每个生命周期作用域的组件在每个嵌套的生命周期作用域中最多只会有一个单一实例.
    /// </summary>
    public class InstancePerLifetimeScope
    {
        public IContainer Init()
        {
            var builder = new ContainerBuilder();

            //生命周期作用域单例模式注册InstancePerLifetimeScope
            builder.RegisterType<Worker>().InstancePerLifetimeScope();

            IContainer container = builder.Build();
            return container;
        }

        public IEnumerable<int> Resolve(IContainer container)
        {
            using (var scope1 = container.BeginLifetimeScope())
            {
                for (var i = 0; i < 5; i++)
                {
                    var worker1 = scope1.Resolve<Worker>();
                    yield return worker1.GetHashCode();
                }
            }

            using (var scope2 = container.BeginLifetimeScope())
            {
                for (var i = 0; i < 5; i++)
                {
                    var worker2 = scope2.Resolve<Worker>();
                    yield return worker2.GetHashCode();
                }
            }
        }
    }
}
