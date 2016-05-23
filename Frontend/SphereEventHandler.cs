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
            GlobalHost.ConnectionManager.GetHubContext<SphereHub>().Clients.All.deleted(id.ToString());
        }

        public void VersionChanged(ActorId id, string version)
        {
            GlobalHost.ConnectionManager.GetHubContext<SphereHub>().Clients.All.versionChanged(id.ToString(), version);
        }

        public void ColorChanged(ActorId id, float red, float green, float blue)
        {
            GlobalHost.ConnectionManager.GetHubContext<SphereHub>().Clients.All.colorChanged(id.ToString(), red, green, blue);
        }
    }
}
