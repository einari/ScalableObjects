﻿using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Objects.Interfaces;

namespace Objects
{
    public class BoxEventRouter : Actor, IBoxEventRouter
    {
        public Task Created(ActorId sphere)
        {
            var events = GetEvent<IBoxEvents>();
            events.Created(sphere);
            return Task.FromResult(0);
        }

        public Task Deleted(ActorId box)
        {
            var events = GetEvent<IBoxEvents>();
            events.Deleted(box);
            return Task.FromResult(0);
        }

        public Task VersionChanged(ActorId box, string version)
        {
            var events = GetEvent<IBoxEvents>();
            events.VersionChanged(box, version);
            return Task.FromResult(0);
        }

        public Task ColorChanged(ActorId box, float red, float green, float blue)
        {
            var events = GetEvent<IBoxEvents>();
            events.ColorChanged(box, red, green, blue);
            return Task.FromResult(0);
        }
    }
}