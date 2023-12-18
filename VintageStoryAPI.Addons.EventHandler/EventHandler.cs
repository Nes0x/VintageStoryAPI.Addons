using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common;
using VintageStoryAPI.Addons.Common.Creators;
using VintageStoryAPI.Addons.Common.Extensions;
using VintageStoryAPI.Addons.EventHandler.Common;
using VintageStoryAPI.Addons.EventHandler.Common.Events;

namespace VintageStoryAPI.Addons.EventHandler;

public class EventHandler<TApi> : IHandler<TApi> where TApi : ICoreAPI
{
    private readonly IInstancesCreator _instancesCreator = new InstancesCreator();
    private readonly IServiceProvider? _provider;

    public EventHandler(IServiceProvider? provider = null)
    {
        _provider = provider;
    }

    public void RegisterAll(Assembly assembly)
    {
        var events = assembly.GetAllTypesFromAssemblyByGeneric<BaseEvent<TApi>>();
        foreach (var @event in events)
        {
            @event.GetMethod("Subscribe").Invoke(_instancesCreator.CreateInstance(@event, _provider), new object[]{_instancesCreator, _provider});
        }
    }
}