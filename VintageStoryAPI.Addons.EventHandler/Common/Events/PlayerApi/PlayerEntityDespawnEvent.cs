using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class PlayerEntityDespawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerEntityDespawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerEntityDespawn += player => ExecuteEvent(instancesCreator, provider, player);
    }
}