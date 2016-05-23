using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace Objects.Interfaces
{
    public class GlobalBoxEventRouter
    {
        public static readonly IBoxEventRouter Instance;

        static GlobalBoxEventRouter()
        {
            Instance = ActorProxy.Create<IBoxEventRouter>(new ActorId(0));
        }
    }
}
