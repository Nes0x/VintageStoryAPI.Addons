using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.Entity;

public abstract class OnEntityDeathEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected OnEntityDeathEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vintagestory.API.Common.Entities.Entity entity, DamageSource damageSource);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnEntityDeath +=
            (entity, damageSource) => ExecuteEvent(instancesCreator, provider, entity, damageSource);
    }
}