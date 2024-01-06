using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Block;

public abstract class DidPlaceBlockEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected DidPlaceBlockEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player,
        int oldBlockId,
        BlockSelection blockSelection,
        ItemStack withItemStack);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.DidPlaceBlock += (player,
            oldBlockId,
             blockSelection,
            withItemStack) => Execute(instanceCreator, provider, player, oldBlockId, blockSelection, withItemStack);
    }
}