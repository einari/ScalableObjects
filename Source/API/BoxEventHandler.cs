using System.Collections.Generic;
using System.IO;
using Microsoft.ServiceFabric.Actors;
using Newtonsoft.Json;
using Objects.Interfaces;

namespace API
{
    public class BoxEventHandler : IBoxEvents
    {
        const string FileName = "c:\\boxes.txt";
        Dictionary<string, ActorRepresentation> _boxes = new Dictionary<string, ActorRepresentation>();

        void LoadState()
        {
            var boxesAsJson = File.ReadAllText(FileName);
            _boxes = JsonConvert.DeserializeObject<Dictionary<string, ActorRepresentation>>(boxesAsJson);
        }

        void WriteState()
        {
            var boxesAsJson = JsonConvert.SerializeObject(_boxes);
            File.WriteAllText(FileName, boxesAsJson);
        }

        public BoxEventHandler()
        {
            LoadState();
        }


        public void ColorChanged(ActorId id, float red, float green, float blue)
        {
        }

        public void Created(ActorId id)
        {
            _boxes[id.ToString()] = new ActorRepresentation { Actor = id.ToString(), Partition = id.GetPartitionKey() };
            WriteState();
        }

        public void Deleted(ActorId id)
        {
            _boxes.Remove(id.ToString());
            WriteState();
        }

        public void VersionChanged(ActorId id, string version)
        {
            
        }
    }
}