using Vintagestory.API.Client;
using Vintagestory.API.Common.Entities;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class OnEntityDespawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected OnEntityDespawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Entity entity, EntityDespawnData reasonData);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnEntityDespawn +=
            (entity, reasonData) => ExecuteEvent(instancesCreator, provider, entity, reasonData);
    }
}