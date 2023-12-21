using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Block;

public abstract class BlockTexturesLoadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected BlockTexturesLoadedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.BlockTexturesLoaded += () => ExecuteEvent(instancesCreator, provider);
    }
}