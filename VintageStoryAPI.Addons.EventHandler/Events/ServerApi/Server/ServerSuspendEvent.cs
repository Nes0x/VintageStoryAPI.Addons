using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Server;

public abstract class ServerSuspendEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected ServerSuspendEvent(TApi api) : base(api)
    {
    }

    public abstract EnumSuspendState Handle();


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.ServerSuspend += () =>
            (EnumSuspendState)ExecuteEvent(instancesCreator, provider)!;
    }
}