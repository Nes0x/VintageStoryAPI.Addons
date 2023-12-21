using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class KeyDownEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected KeyDownEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(KeyEvent keyEvent);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.KeyDown += keyEvent => ExecuteEvent(instancesCreator, provider, keyEvent);
    }
}