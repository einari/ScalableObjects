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
            var activeActors = new List<object>();

            var serviceUris = new[] {
                new Uri("fabric:/ScalableObjects/SphereActorService"),
                new Uri("fabric:/ScalableObjects/BoxActorService")
            };

            foreach (var serviceUri in serviceUris)
            {
                var service = ActorServiceProxy.Create(serviceUri, 0);

                ContinuationToken continuationToken = null;
                do
                {
                    var page = await service.GetActorsAsync(continuationToken, CancellationToken.None);
                    activeActors.AddRange(page.Items.Where(actor => actor.IsActive).Select(actor => new
                    {
                        actor = actor.ActorId.ToString(),
                        partition = actor.ActorId.GetPartitionKey(),
                        type = GetTypeFromServiceUri(serviceUri)
                    }));
                    continuationToken = page.ContinuationToken;
                } while (continuationToken != null);
            }

            return activeActors;
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


        string GetTypeFromServiceUri(Uri uri)
        {
            if (uri.AbsolutePath.Contains("Sphere")) return "Sphere";
            if (uri.AbsolutePath.Contains("Box")) return "Box";
            return "Unknown";
        }

    }
}
