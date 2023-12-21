using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class PauseResumeEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PauseResumeEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(bool isPaused);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PauseResume += isPaused => ExecuteEvent(instancesCreator, provider, isPaused);
    }
}