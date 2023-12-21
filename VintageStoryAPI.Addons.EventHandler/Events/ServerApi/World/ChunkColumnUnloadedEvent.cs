using Vintagestory.API.MathTools;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.World;

public abstract class ChunkColumnUnloadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected ChunkColumnUnloadedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vec3i chunkCoordinates);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.ChunkColumnUnloaded += (chunkCoordinates) =>
            ExecuteEvent(instancesCreator, provider, chunkCoordinates);
    }
}