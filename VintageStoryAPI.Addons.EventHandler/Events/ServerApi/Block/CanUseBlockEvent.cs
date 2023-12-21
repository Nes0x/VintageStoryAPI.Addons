using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Block;

public abstract class CanUseBlockEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected CanUseBlockEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(IServerPlayer player, BlockSelection blockSelection);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.CanUseBlock += (player, blockSelection) => (bool)ExecuteEvent(instancesCreator, provider, player, blockSelection)!;
    }
}