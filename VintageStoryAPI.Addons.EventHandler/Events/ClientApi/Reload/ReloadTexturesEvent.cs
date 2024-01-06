using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Reload;

public abstract class ReloadTexturesEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ReloadTexturesEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.ReloadTextures += () => Execute(instanceCreator, provider);
    }
}