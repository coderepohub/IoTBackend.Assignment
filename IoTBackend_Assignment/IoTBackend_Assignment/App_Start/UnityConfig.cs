using AzureStorage_Framework;
using IoTBackend.Interfaces;
using IoTBackend.WeatherReportStation;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace IoTBackend_Assignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
        
            container.RegisterType<IBlobFramework,BlobFramework>();
            container.RegisterType<IWeatherReport,WeatherReport>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}