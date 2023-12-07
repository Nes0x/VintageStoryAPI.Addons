using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Common;

internal class Event<TApi> where TApi : ICoreAPI
{
    public Event(MethodInfo eventMethodHandler, EventAttribute<TApi> eventProperties)
    {
        EventMethodHandler = eventMethodHandler;
        EventProperties = eventProperties;
    }

    public MethodInfo EventMethodHandler { get; } 
    public EventAttribute<TApi> EventProperties { get; } 
}