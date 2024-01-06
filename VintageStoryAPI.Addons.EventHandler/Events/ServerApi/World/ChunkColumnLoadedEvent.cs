using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.World;

public abstract class ChunkColumnLoadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected ChunkColumnLoadedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vec2i chunkCoordinates, IWorldChunk[] chunks);


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.ChunkColumnLoaded += (chunkCoordinates, chunks) =>
            Execute(instanceCreator, provider, chunkCoordinates, chunks);
    }
}