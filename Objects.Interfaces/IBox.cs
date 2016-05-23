﻿using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Objects.Interfaces
{
    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IBox : IActor
    {
        Task Create();
        Task Delete();
    }
}
