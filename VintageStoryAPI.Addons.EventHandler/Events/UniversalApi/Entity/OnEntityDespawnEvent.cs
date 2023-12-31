using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.Entity;

public abstract class OnEntityDespawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected OnEntityDespawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vintagestory.API.Common.Entities.Entity entity, EntityDespawnData reasonData);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.OnEntityDespawn +=
            (entity, reasonData) => Execute(instanceCreator, provider, entity, reasonData);
    }
}