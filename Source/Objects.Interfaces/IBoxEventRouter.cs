using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Objects.Interfaces
{
    public interface IBoxEventRouter : IActor, IActorEventPublisher<IBoxEvents>
    {
        Task Created(ActorId box);
        Task Deleted(ActorId box);
        Task ColorChanged(ActorId id, float red, float green, float blue);
        Task VersionChanged(ActorId id, string version);
    }
}
