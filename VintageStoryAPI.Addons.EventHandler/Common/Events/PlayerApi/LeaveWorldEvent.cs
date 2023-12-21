using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class LeaveWorldEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected LeaveWorldEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.LeaveWorld += () => ExecuteEvent(instancesCreator, provider);
    }
}