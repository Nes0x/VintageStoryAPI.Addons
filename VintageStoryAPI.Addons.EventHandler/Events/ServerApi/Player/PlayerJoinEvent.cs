using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerJoinEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerJoinEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerJoin += player =>
            ExecuteEvent(instancesCreator, provider, player);
    }
}