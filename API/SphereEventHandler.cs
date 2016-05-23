using System.Collections.Generic;
using System.IO;
using Microsoft.ServiceFabric.Actors;
using Newtonsoft.Json;
using Objects.Interfaces;

namespace API
{
    public class SphereEventHandler : ISphereEvents
    {
        const string FileName = "c:\\spheres.txt";
        Dictionary<string, ActorRepresentation> _spheres = new Dictionary<string, ActorRepresentation>();

        void LoadState()
        {
            var spheresAsJson = File.ReadAllText(FileName);
            _spheres = JsonConvert.DeserializeObject<Dictionary<string, ActorRepresentation>>(spheresAsJson);
        }

        void WriteState()
        {
            var spheresAsJson = JsonConvert.SerializeObject(_spheres);
            File.WriteAllText(FileName, spheresAsJson);
        }

        public SphereEventHandler()
        {
            LoadState();
        }


        public void ColorChanged(ActorId id, float red, float green, float blue)
        {
        }

        public void Created(ActorId id)
        {
            _spheres[id.ToString()] = new ActorRepresentation { Actor = id.ToString(), Partition = id.GetPartitionKey() };
            WriteState();
        }

        public void Deleted(ActorId id)
        {
            _spheres.Remove(id.ToString());
            WriteState();
        }

        public void VersionChanged(ActorId id, string version)
        {
            
        }
    }
}