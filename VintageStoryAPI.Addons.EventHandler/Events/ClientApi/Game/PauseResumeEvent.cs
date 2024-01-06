using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Game;

public abstract class PauseResumeEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PauseResumeEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(bool isPaused);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PauseResume += isPaused => Execute(instanceCreator, provider, isPaused);
    }
}