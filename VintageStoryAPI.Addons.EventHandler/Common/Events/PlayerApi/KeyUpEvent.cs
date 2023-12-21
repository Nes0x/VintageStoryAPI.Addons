using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class KeyUpEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected KeyUpEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(KeyEvent keyEvent);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.KeyUp += keyEvent => ExecuteEvent(instancesCreator, provider, keyEvent);
    }
}