using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Game;

public abstract class SaveGameLoadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected SaveGameLoadedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.SaveGameLoaded += () =>
            ExecuteEvent(instancesCreator, provider);
    }
}