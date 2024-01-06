using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerSwitchGameModeEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerSwitchGameModeEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player);


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PlayerSwitchGameMode += player =>
            Execute(instanceCreator, provider, player);
    }
}