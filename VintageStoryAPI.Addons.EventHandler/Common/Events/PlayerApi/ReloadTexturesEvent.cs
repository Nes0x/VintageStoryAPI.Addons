using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class ReloadTexturesEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ReloadTexturesEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.ReloadTextures += () => ExecuteEvent(instancesCreator, provider);
    }
}