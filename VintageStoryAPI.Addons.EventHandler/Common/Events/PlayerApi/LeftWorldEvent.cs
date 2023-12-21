using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

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