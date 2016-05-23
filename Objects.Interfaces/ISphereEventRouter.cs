using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Objects.Interfaces
{
    public interface ISphereEventRouter : IActor, IActorEventPublisher<ISphereEvents>
    {
        Task Created(ActorId sphere);
        Task Deleted(ActorId sphere);
        Task ColorChanged(ActorId id, float red, float green, float blue);
        Task VersionChanged(ActorId id, string version);
    }
}
