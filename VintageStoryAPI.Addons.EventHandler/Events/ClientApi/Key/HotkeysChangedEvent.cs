using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Key;

public abstract class HotkeysChangedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected HotkeysChangedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.HotkeysChanged += () => ExecuteEvent(instancesCreator, provider);
    }
}