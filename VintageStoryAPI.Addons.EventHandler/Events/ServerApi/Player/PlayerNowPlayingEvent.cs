using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerNowPlayingEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerNowPlayingEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerNowPlaying += player =>
            ExecuteEvent(instancesCreator, provider, player);
    }
}