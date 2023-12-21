using Vintagestory.API.Datastructures;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerChatEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerChatEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player,
        int channelId,
        ref string message,
        ref string data,
        BoolRef consumed);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerChat += (
                IServerPlayer player,
        int channelId,
        ref string message,
        ref string data,
        BoolRef consumed
                ) =>
            ExecuteEvent(
                instancesCreator,
                provider, player,
                channelId,
                message,
                data,
                consumed);
    }
}