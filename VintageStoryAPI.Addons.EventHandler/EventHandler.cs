using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common;
using VintageStoryAPI.Addons.Common.Creators;
using VintageStoryAPI.Addons.EventHandler.Common;

namespace VintageStoryAPI.Addons.EventHandler;

public class EventHandler<TApi> : IHandler<TApi> where TApi : ICoreAPI
{
    private readonly TApi _api;
    private readonly IParser<Event<TApi>> _eventsParser = new EventsParser<TApi>();
    private readonly IInstancesCreator _instancesCreator = new InstancesCreator();
    private readonly IServiceProvider? _provider;

    public EventHandler(TApi api, IServiceProvider? provider = null)
    {
        _api = api;
        _provider = provider;
    }

    public void RegisterAll(Assembly assembly)
    {
        var events = _eventsParser.Parse(assembly);
        var apiType = _api.Event.GetType();
        foreach (var @event in events)
        {
            var eventInfo = apiType.GetEvent(@event.EventProperties.EventType.ToString())!;
            var handlerType = eventInfo.EventHandlerType!;
            Delegate handler;
            try
            {
                handler = Delegate.CreateDelegate(handlerType,
                    _instancesCreator.CreateInstance(@event.EventMethodHandler.DeclaringType!, _provider),
                    @event.EventMethodHandler);
            }
            catch (ArgumentException)
            {
                _api.Logger.Error(
                    $"Your {@event.EventMethodHandler.Name} method from {@event.GetType().Name} class has a bad signature.");
                continue;
            }

            eventInfo.AddEventHandler(_api.Event, handler);
        }
    }
}