using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

public abstract class PlayerDeathEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerDeathEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerDeath += player => ExecuteEvent(instancesCreator, provider, player);
    }
}