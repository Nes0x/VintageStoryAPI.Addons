using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Block;

public abstract class BlockChangedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected BlockChangedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vintagestory.API.Common.Block block, Vintagestory.API.Common.Block oldBlock);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.BlockChanged += (block, oldBlock) => Execute(instanceCreator, provider, block, oldBlock);
    }
}