using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Game;

public abstract class FileDropEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected FileDropEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(FileDropEvent fileDropEvent);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.FileDrop += fileDropEvent => Execute(instanceCreator, provider, fileDropEvent);
    }
}