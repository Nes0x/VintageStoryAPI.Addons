using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.World;

public abstract class BeginChunkColumnLoadChunkThreadEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected BeginChunkColumnLoadChunkThreadEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(  IServerMapChunk mapChunk,
        int chunkX,
        int chunkZ,
        IWorldChunk[] chunks);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.BeginChunkColumnLoadChunkThread += (mapChunk,
                chunkX,
                chunkZ,
                chunks) =>
            ExecuteEvent(instancesCreator, provider, mapChunk, chunkX, chunkZ, chunks);
    }
}