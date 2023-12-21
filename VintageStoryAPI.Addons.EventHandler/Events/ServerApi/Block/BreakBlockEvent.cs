using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Block;

public abstract class BreakBlockEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected BreakBlockEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player,
        BlockSelection blockSelection,
        ref float dropQuantityMultiplier,
        ref EnumHandling handling);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.BreakBlock += (IServerPlayer player,
                BlockSelection blockSelection,
                ref float dropQuantityMultiplier,
                ref EnumHandling handling) =>
            ExecuteEvent(instancesCreator, provider, player, blockSelection, dropQuantityMultiplier, handling);
    }
}