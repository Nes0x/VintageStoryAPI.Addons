using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class BlockChangedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected BlockChangedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Block block, Block oldBlock);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.BlockChanged += (block, oldBlock) => ExecuteEvent(instancesCreator, provider, block, oldBlock);
    }
}