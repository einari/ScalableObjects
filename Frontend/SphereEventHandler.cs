using System;
using Microsoft.AspNet.SignalR;
using Microsoft.ServiceFabric.Actors;
using Objects.Interfaces;

namespace Frontend
{
    public class SphereEventHandler : ISphereEvents
    {

        public void Created(ActorId id)
        {
            GlobalHost.ConnectionManager.GetHubContext<SphereHub>().Clients.All.created(id.ToString());
        }

        public void Deleted(ActorId id)
        {
        }

        public void VersionChanged(ActorId id, string version)
        {
        }

        public void ColorChanged(ActorId id, float red, float green, float blue)
        {
            var i = 0;
            i++;
        }
    }
}
