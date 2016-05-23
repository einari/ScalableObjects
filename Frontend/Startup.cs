using System.IO;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.ServiceFabric.Actors.Client;
using Objects.Interfaces;
using Owin;

namespace Frontend
{
    public static class Startup
    {

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            var fileServerOptions = new FileServerOptions
            {
                EnableDefaultFiles = true
            };

            var currentDir = Directory.GetCurrentDirectory();
            var debugString = "\\bin\\x64\\debug";
            if( currentDir.ToLowerInvariant().Contains(debugString))
            {
                var index = currentDir.ToLowerInvariant().IndexOf(debugString);
                var root = $"{currentDir.Substring(0, index)}\\PackageRoot\\Code";

                fileServerOptions.EnableDirectoryBrowsing = true;
                fileServerOptions.FileSystem = new PhysicalFileSystem(root);
            }

            appBuilder.UseFileServer(fileServerOptions);

            appBuilder.MapSignalR();

            /*
            GlobalSphereEventRouter.Instance.SubscribeAsync<ISphereEvents>(new SphereEventHandler());
            GlobalBoxEventRouter.Instance.SubscribeAsync<IBoxEvents>(new BoxEventHandler());*/
        }
    }
}
