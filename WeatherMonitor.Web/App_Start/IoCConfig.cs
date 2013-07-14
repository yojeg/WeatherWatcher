namespace WeatherMonitor.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;

    public class IocConfig
    {
        public static IDependencyResolver CreateDependencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetCallingAssembly());

            return new AutofacDependencyResolver(builder.Build());
        }         
    }
}