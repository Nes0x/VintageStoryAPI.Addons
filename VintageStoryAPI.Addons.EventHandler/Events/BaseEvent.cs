using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events;

public abstract class BaseEvent<TApi> where TApi : ICoreAPI
{
    protected BaseEvent(TApi api)
    {
        Api = api;
    }

    protected TApi Api { get; }

    public abstract void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider);

    protected object? Execute(IInstanceCreator instanceCreator, IServiceProvider provider,
        params object[] arguments)
    {
        var instance = instanceCreator.Create(GetType(), provider);
        return GetType().GetMethod("Handle")!.Invoke(instance, arguments);
    }
}