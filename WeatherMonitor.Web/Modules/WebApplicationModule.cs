namespace WeatherMonitor.Web.Modules
{
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Controllers;
    using Module = Autofac.Module;

    public class WebApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterFilterProvider();
            builder.RegisterControllers(Assembly.GetAssembly(typeof(HomeController)));
        }
         
    }
}