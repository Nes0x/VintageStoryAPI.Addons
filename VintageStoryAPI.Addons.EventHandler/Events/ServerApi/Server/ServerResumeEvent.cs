using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Server;

public abstract class ServerResumeEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected ServerResumeEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.SaveGameCreated += () =>
            Execute(instanceCreator, provider);
    }
}