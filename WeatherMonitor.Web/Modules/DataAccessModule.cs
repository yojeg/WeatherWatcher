namespace WeatherMonitor.Web.Modules
{
    using Autofac;
    using DataAccessLayer;
    using Autofac.Integration.Mvc;

    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WeatherMonitorDbContext>()
                .InstancePerHttpRequest();
        }         
         
    }
}