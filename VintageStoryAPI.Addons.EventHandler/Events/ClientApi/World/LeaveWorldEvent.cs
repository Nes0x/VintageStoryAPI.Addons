using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.World;

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