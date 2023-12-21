using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class FileDropEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected FileDropEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(FileDropEvent fileDropEvent);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.FileDrop += fileDropEvent => ExecuteEvent(instancesCreator, provider, fileDropEvent);
    }
}