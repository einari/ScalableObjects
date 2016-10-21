using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Runtime;
using Newtonsoft.Json;

namespace Objects
{
    public static class StateManagerExtensions
    {

        public static async Task<T> GetState<T>(this IActorStateManager stateManager, string stateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var stateAsString = await stateManager.TryGetStateAsync<string>(stateName, cancellationToken);
            if( stateAsString.HasValue ) return JsonConvert.DeserializeObject<T>(stateAsString.Value);
            return default(T);
        }

        public static async Task SetState<T>(this IActorStateManager stateManager, string stateName, T state, CancellationToken cancellationToken = default(CancellationToken))
        {
            var stateAsString = JsonConvert.SerializeObject(state);
            await stateManager.SetStateAsync<string>(stateName, stateAsString, cancellationToken);
        }
    }
}
