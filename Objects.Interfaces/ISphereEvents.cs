using System;
using Microsoft.ServiceFabric.Actors;

namespace Objects.Interfaces
{
    public interface ISphereEvents : IActorEvents
    {
        void Created(ActorId id);
        void Deleted(ActorId id);
        void ColorChanged(ActorId id, float red, float green, float blue);
        void VersionChanged(ActorId id, string version);
    }
}
