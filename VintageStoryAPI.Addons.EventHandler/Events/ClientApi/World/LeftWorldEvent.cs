using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.World;

public abstract class LeftWorldEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected LeftWorldEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.LeftWorld += () => ExecuteEvent(instancesCreator, provider);
    }
}