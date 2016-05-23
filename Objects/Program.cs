using System;
using System.Threading;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Objects
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                ActorRuntime.RegisterActorAsync<Sphere>();
                ActorRuntime.RegisterActorAsync<SphereEventRouter>();

                ActorRuntime.RegisterActorAsync<Box>();
                ActorRuntime.RegisterActorAsync<BoxEventRouter>();

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
