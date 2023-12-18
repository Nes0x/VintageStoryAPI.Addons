using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events;

public abstract class BaseEvent<TApi> where TApi : ICoreAPI
{
    protected TApi Api { get; }

    protected BaseEvent(TApi api)
    {
        Api = api;
    }

    public abstract void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider);
}