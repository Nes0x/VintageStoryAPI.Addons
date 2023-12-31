using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Block;

public abstract class DidUseBlockEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected DidUseBlockEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player, BlockSelection blockSelection);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.DidUseBlock += (player, blockSelection) => Execute(instanceCreator, provider, player, blockSelection);
    }
}