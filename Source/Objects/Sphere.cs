﻿using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Objects.Interfaces;

namespace Objects
{
    [StatePersistence(StatePersistence.Persisted)]
    internal class Sphere : Actor, ISphere
    {
        const string ColorState = "Color";

        static Color CurrentColor = Colors.Red;

        public Sphere(ActorService actorService, ActorId actorId) : base(actorService, actorId) { }

        public Task Create()
        {
            GlobalSphereEventRouter.Instance.Created(Id);
            GlobalSphereEventRouter.Instance.ColorChanged(Id, CurrentColor.Red, CurrentColor.Green, CurrentColor.Blue);
            return StateManager.SetState(ColorState, CurrentColor);
        }

        public Task Delete()
        {
            GlobalSphereEventRouter.Instance.Deleted(Id);
            return Task.FromResult(0);
        }

        protected override async Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");
            var color = await StateManager.GetState<Color>(ColorState);
            if( color != CurrentColor )
            {
                await StateManager.SetState(ColorState, CurrentColor);
                await GlobalSphereEventRouter.Instance.ColorChanged(Id, CurrentColor.Red, CurrentColor.Green, CurrentColor.Blue);
            }
        }
    }
}
