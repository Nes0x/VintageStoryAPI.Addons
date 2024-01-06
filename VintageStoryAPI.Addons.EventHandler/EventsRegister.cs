using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common;
using VintageStoryAPI.Addons.Common.Extensions;
using VintageStoryAPI.Addons.EventHandler.Events;

namespace VintageStoryAPI.Addons.EventHandler;

public class EventsRegister<TApi> : IRegistrable where TApi : class, ICoreAPI
{
    private readonly IServiceProvider _provider;
    private readonly IInstanceCreator _instanceCreator;

    public EventsRegister(TApi api, IServiceProvider? provider = null)
    {
        _provider = provider ?? new ServiceCollection().AddSingleton(_ => api).BuildServiceProvider();
        _instanceCreator = new InstanceCreator();
    }

    public void RegisterAll(Assembly assembly)
    {
        if (_provider.GetService(typeof(TApi)) is null) throw new ArgumentNullException(typeof(TApi).Name, $"You must add {typeof(TApi).Name} to provider, to register events.");
        
        var events = assembly
            .GetAllTypes<BaseEvent<TApi>>()
            .Select(type => (BaseEvent<TApi>) _instanceCreator.Create(type, _provider)!);
        foreach (var @event in events)
        {
            @event.Subscribe(_instanceCreator, _provider);
        }
    }
}