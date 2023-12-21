using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerRespawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerRespawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerRespawn += player =>
            ExecuteEvent(instancesCreator, provider, player);
    }
}