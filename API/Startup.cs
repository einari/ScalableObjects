using System.Web.Http;
using Microsoft.ServiceFabric.Actors.Client;
using Objects.Interfaces;
using Owin;

namespace API
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

            GlobalSphereEventRouter.Instance.SubscribeAsync<ISphereEvents>(new SphereEventHandler());
            GlobalBoxEventRouter.Instance.SubscribeAsync<IBoxEvents>(new BoxEventHandler());

        }
    }
}
