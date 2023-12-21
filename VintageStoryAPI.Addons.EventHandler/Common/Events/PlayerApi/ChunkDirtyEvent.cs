using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class ChunkDirtyEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ChunkDirtyEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vec3i chunkCoordinates,
        IWorldChunk chunk,
        EnumChunkDirtyReason reason);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.ChunkDirty += (chunkCoordinates,
            chunk,
            reason) => ExecuteEvent(instancesCreator, provider, chunkCoordinates, chunk, reason);
    }
}