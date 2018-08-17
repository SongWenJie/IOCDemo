using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.Lifetime
{
    /// <summary>
    /// 全局单例模式
    /// 在根容器和所有嵌套作用域内所有的请求都将会返回同一个实例.
    /// 当你解析一个单一实例组件时, 无论你从哪里请求它, 你都讲获得相同的实例.
    /// </summary>
    public class SingleInstance
    {
        public IContainer Init()
        {
            var builder = new ContainerBuilder();

            //全局单例模式注册SingleInstance()
            builder.RegisterType<Worker>().SingleInstance();

            IContainer container = builder.Build();
            return container;
        }

        public IEnumerable<int> Resolve(IContainer container)
        {
            var worker = container.Resolve<Worker>();
            yield return worker.GetHashCode();

            using (var scope1 = container.BeginLifetimeScope())
            {
                for (var i = 0; i < 5; i++)
                {
                    var worker1 = scope1.Resolve<Worker>();

                    using (var scope2 = scope1.BeginLifetimeScope())
                    {
                        var worker2 = scope2.Resolve<Worker>();

                        yield return worker1.GetHashCode();
                        yield return worker2.GetHashCode();
                    }
                }
            }
        }
    }
}
