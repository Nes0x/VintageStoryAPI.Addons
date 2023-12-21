using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

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