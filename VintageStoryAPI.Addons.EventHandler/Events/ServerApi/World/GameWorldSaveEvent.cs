using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.World;

public abstract class GameWorldSaveEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected GameWorldSaveEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle();


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.GameWorldSave += () =>
            Execute(instanceCreator, provider);
    }
}