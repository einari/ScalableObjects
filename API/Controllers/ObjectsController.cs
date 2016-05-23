using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Objects.Interfaces;

namespace API.Controllers
{
    public class ObjectsController : ApiController
    {
        // GET api/objects 
        public IEnumerable<string> Get()
        {
            return new string[] { };
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
                    var box = ActorProxy.Create<ISphere>(actorId);
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
