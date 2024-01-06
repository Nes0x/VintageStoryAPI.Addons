using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

public abstract class PlayerLeaveEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerLeaveEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PlayerLeave += player => Execute(instanceCreator, provider, player);
    }
}