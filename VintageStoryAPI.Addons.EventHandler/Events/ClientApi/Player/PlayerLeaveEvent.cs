using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

public abstract class PlayerLeaveEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerLeaveEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerLeave += player => ExecuteEvent(instancesCreator, provider, player);
    }
}