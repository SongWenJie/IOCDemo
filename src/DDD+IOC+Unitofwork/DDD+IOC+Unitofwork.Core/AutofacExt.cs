using Autofac;
using Autofac.Integration.WebApi;
using DDD_IOC_Unitofwork.Application;
using DDD_IOC_Unitofwork.Domin;
using DDD_IOC_Unitofwork.Domin.Repository;
using DDD_IOC_Unitofwork.Infrastructure;
using DDD_IOC_Unitofwork.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DDD_IOC_Unitofwork.Core
{
    public class AutofacExt
    {
        static IContainer _container;
        public static void Init()
        {
            var builder = new ContainerBuilder();
            //注册为每个请求一个实例(Instance Per Request)，则api返回true
            //builder.RegisterType<Unitofwork>().As<IUnitofwork>().InstancePerRequest();
            //默认的每个依赖一个实例(Instance Per Dependency)，则api返回false
            builder.RegisterType<Unitofwork>().As<IUnitofwork>();
            
            builder.RegisterType<ARepository>().As<IARepository>();
            builder.RegisterType<BRepository>().As<IBRepository>();
            builder.RegisterType<ABCApp>();
            builder.RegisterType<ABCService>();
            
            // 注册apicontroller，使用属性注入
            builder.RegisterApiControllers(Assembly.GetCallingAssembly()).PropertiesAutowired();

            _container = builder.Build();

            //Set the WebApi DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container.BeginLifetimeScope());

        }
    }
}
