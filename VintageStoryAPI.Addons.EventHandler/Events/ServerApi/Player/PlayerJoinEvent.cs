using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerJoinEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerJoinEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PlayerJoin += player =>
            Execute(instanceCreator, provider, player);
    }
}