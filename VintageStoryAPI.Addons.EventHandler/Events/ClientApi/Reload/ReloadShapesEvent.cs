using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Reload;

public abstract class ReloadShapesEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ReloadShapesEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.ReloadShapes += () => ExecuteEvent(instancesCreator, provider);
    }
}