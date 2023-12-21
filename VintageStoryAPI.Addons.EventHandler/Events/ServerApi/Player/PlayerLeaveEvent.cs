using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerLeaveEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerLeaveEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerLeave += player =>
            ExecuteEvent(instancesCreator, provider, player);
    }
}