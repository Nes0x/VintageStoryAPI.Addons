using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

public abstract class IsPlayerReadyEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected IsPlayerReadyEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(ref EnumHandling handling);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.IsPlayerReady += (ref EnumHandling handling) =>
            (bool)Execute(instanceCreator, provider, handling)!;
    }
}