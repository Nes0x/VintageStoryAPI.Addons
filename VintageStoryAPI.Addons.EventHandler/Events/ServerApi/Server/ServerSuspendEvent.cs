using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Server;

public abstract class ServerSuspendEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected ServerSuspendEvent(TApi api) : base(api)
    {
    }

    public abstract EnumSuspendState Handle();


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.ServerSuspend += () =>
            (EnumSuspendState)Execute(instanceCreator, provider)!;
    }
}