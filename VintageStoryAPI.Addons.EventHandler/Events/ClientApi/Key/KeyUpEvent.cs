using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Key;

public abstract class KeyUpEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected KeyUpEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(KeyEvent keyEvent);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.KeyUp += keyEvent => Execute(instanceCreator, provider, keyEvent);
    }
}