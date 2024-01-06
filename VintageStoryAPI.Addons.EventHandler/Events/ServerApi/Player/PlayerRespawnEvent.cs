using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerRespawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerRespawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PlayerRespawn += player =>
            Execute(instanceCreator, provider, player);
    }
}