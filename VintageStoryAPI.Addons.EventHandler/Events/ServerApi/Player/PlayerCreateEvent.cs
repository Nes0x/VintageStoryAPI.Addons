using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerCreateEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerCreateEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerCreate += player =>
            ExecuteEvent(instancesCreator, provider, player);
    }
}