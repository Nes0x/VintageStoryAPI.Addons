using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Game;

public abstract class SaveGameCreatedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected SaveGameCreatedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.SaveGameCreated += () =>
            Execute(instanceCreator, provider);
    }
}