using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.Entity;

public abstract class OnEntitySpawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected OnEntitySpawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vintagestory.API.Common.Entities.Entity entity);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.OnEntitySpawn += entity => Execute(instanceCreator, provider, entity);
    }
}