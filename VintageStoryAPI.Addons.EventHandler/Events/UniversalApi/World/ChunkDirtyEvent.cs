using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.World;

public abstract class ChunkDirtyEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected ChunkDirtyEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vec3i chunkCoordinates,
        IWorldChunk chunk,
        EnumChunkDirtyReason reason);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider? provider)
    {
        Api.Event.ChunkDirty += (chunkCoordinates,
            chunk,
            reason) => Execute(instanceCreator, provider, chunkCoordinates, chunk, reason);
    }
}