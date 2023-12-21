using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class OnEntityDeathEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected OnEntityDeathEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Entity entity, DamageSource damageSource);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnEntityDeath +=
            (entity, damageSource) => ExecuteEvent(instancesCreator, provider, entity, damageSource);
    }
}