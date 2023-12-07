using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common;
using VintageStoryAPI.Addons.Common.Extensions;
using VintageStoryAPI.Addons.EventHandler.Common;

namespace VintageStoryAPI.Addons.EventHandler;

internal class EventsParser<TApi> : IParser<Event<TApi>> where TApi : ICoreAPI
{
    public IEnumerable<Event<TApi>> Parse(Assembly assembly)
    {
        var eventMethods = assembly
            .GetSpecificMethodsFromTypes<EventModule>(method => 
                method.GetCustomAttribute(typeof(EventAttribute<TApi>), true) is not null);
        return eventMethods.Select(eventMethod =>
            new Event<TApi>(eventMethod, eventMethod.GetCustomAttribute<EventAttribute<TApi>>()!));
    }
}