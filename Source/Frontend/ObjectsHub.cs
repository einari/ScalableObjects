using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace Frontend
{
    public class ObjectsHub : Hub
    {
        public class ObjectRepresentation
        {
            public string actor { get; set; }
            public string partition { get; set; }
            public string type { get; set; }
        }


        public IEnumerable<ObjectRepresentation> GetObjects()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8163");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("/api/objects").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                var objects = JsonConvert.DeserializeObject<IEnumerable<ObjectRepresentation>>(json);
                return objects;
            }

            return new ObjectRepresentation[0];
        }  

    }
}
