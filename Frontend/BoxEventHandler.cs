using Microsoft.AspNet.SignalR;
using Microsoft.ServiceFabric.Actors;
using Objects.Interfaces;

namespace Frontend
{
    public class BoxEventHandler : IBoxEvents
    {

        public void Created(ActorId id)
        {
            GlobalHost.ConnectionManager.GetHubContext<BoxHub>().Clients.All.created(id.ToString());
        }

        public void Deleted(ActorId id)
        {
            GlobalHost.ConnectionManager.GetHubContext<BoxHub>().Clients.All.deleted(id.ToString());
        }

        public void VersionChanged(ActorId id, string version)
        {
            GlobalHost.ConnectionManager.GetHubContext<BoxHub>().Clients.All.versionChanged(id.ToString(), version);
        }

        public void ColorChanged(ActorId id, float red, float green, float blue)
        {
            GlobalHost.ConnectionManager.GetHubContext<BoxHub>().Clients.All.colorChanged(id.ToString(), red, green, blue);
        }
    }
}
