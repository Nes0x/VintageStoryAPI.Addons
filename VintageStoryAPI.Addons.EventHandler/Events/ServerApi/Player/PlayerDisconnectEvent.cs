using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerDisconnectEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerDisconnectEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PlayerDisconnect += player =>
            Execute(instanceCreator, provider, player);
    }
}