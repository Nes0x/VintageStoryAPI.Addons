using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events;

public abstract class BaseEvent<TApi> where TApi : ICoreAPI
{
    protected BaseEvent(TApi api)
    {
        Api = api;
    }

    protected TApi Api { get; }

    public abstract void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider);

    protected object? ExecuteEvent(IInstancesCreator instancesCreator, IServiceProvider provider,
        params object[] arguments)
    {
        var instance = instancesCreator.CreateInstance(GetType(), provider);
        return GetType().GetMethod("Handle")!.Invoke(instance, arguments);
    }
}