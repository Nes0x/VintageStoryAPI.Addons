using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi;

public abstract class OnTrySpawnEntityEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected OnTrySpawnEntityEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(IBlockAccessor blockAccessor,
        ref EntityProperties properties,
        Vec3d spawnPosition,
        long herdId);


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.OnTrySpawnEntity += (IBlockAccessor blockAccessor,
                ref EntityProperties properties,
                Vec3d spawnPosition,
                long herdId) =>
            (bool)Execute(instanceCreator, provider, blockAccessor, properties, spawnPosition, herdId)!;
    }
}