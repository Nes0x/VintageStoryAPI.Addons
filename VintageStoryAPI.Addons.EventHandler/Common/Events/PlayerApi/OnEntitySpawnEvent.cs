using Vintagestory.API.Client;
using Vintagestory.API.Common.Entities;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class OnEntitySpawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected OnEntitySpawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Entity entity);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnEntitySpawn += entity => ExecuteEvent(instancesCreator, provider, entity);
    }
}