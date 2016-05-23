using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Objects.Interfaces;

namespace Objects
{
    public class SphereEventRouter : Actor, ISphereEventRouter
    {
        public Task Created(ActorId sphere)
        {
            var events = GetEvent<ISphereEvents>();
            events.Created(sphere);
            return Task.FromResult(0);
        }

        public Task Deleted(ActorId sphere)
        {
            var events = GetEvent<ISphereEvents>();
            events.Deleted(sphere);
            return Task.FromResult(0);
        }

        public Task VersionChanged(ActorId sphere, string version)
        {
            var events = GetEvent<ISphereEvents>();
            events.VersionChanged(sphere, version);
            return Task.FromResult(0);
        }

        public Task ColorChanged(ActorId sphere, float red, float green, float blue)
        {
            var events = GetEvent<ISphereEvents>();
            events.ColorChanged(sphere, red, green, blue);
            return Task.FromResult(0);
        }
    }
}
