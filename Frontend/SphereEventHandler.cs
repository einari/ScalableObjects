using System;
using Microsoft.ServiceFabric.Actors;
using Objects.Interfaces;

namespace Frontend
{
    public class SphereEventHandler : ISphereEvents
    {

        public void Created(ActorId id)
        {
            var i = 0;
            i++;
        }

        public void Deleted(ActorId id)
        {
        }

        public void VersionChanged(ActorId id, string version)
        {
        }

        public void ColorChanged(ActorId id, float red, float green, float blue)
        {
        }

    }
}
