using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Key;

public abstract class KeyDownEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected KeyDownEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(KeyEvent keyEvent);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.KeyDown += keyEvent => Execute(instanceCreator, provider, keyEvent);
    }
}