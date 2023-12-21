using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

public abstract class PlayerJoinEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerJoinEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerJoin += player => ExecuteEvent(instancesCreator, provider, player);
    }
}