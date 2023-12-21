using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Block;

public abstract class DidBreakBlockEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected DidBreakBlockEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle( IServerPlayer byPlayer,
        int oldBlockId,
        BlockSelection blockSelection);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.DidBreakBlock += (player, oldBlockId, blockSelection) => ExecuteEvent(instancesCreator, provider, player, oldBlockId, blockSelection);
    }
}