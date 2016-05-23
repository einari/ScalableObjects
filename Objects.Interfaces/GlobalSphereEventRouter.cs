using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace Objects.Interfaces
{
    public class GlobalSphereEventRouter
    {
        public static readonly ISphereEventRouter Instance;

        static GlobalSphereEventRouter()
        {
            Instance = ActorProxy.Create<ISphereEventRouter>(new ActorId(0));
        }
    }
}
