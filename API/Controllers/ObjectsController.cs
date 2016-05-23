using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Query;
using Objects.Interfaces;

namespace API.Controllers
{
    public class ObjectsController : ApiController
    {
        // GET api/objects 
        public async Task<IEnumerable<object>> Get()
        {
            var activeActors = new List<ActorInformation>();
            var serviceUri = new Uri("fabric:/ScalableObjects/SphereActorService");
            var service = ActorServiceProxy.Create(serviceUri,0);

            ContinuationToken continuationToken = null;
            do
            {
                var page = await service.GetActorsAsync(continuationToken, CancellationToken.None);
                activeActors.AddRange(page.Items.Where(actor => actor.IsActive));
                continuationToken = page.ContinuationToken;
            } while (continuationToken != null);

            return activeActors.Select(a=>new {
                actor = a.ActorId.ToString(),
                partition = a.ActorId.GetPartitionKey()
            });
        }

        // POST api/objects
        public void Post([FromBody]string objectType)
        {
            var actorId = new ActorId(Guid.NewGuid());
            switch( objectType )
            {
                case "sphere":
                    var sphere = ActorProxy.Create<ISphere>(actorId);
                    sphere.Create();
                    break;
                case "box":
                    var box = ActorProxy.Create<IBox>(actorId);
                    box.Create();
                    break;
            }
        }

        // DELETE api/objects/5 
        public void Delete(string id)
        {
            var actorId = new ActorId(Guid.Parse(id));
            var actor = ActorProxy.Create<ISphere>(actorId);
            actor.Delete();
        }
    }
}
