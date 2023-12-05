using System.Reflection;

namespace VintageStoryAPI.Addons.EventHandler.Common;

internal class Event
{
    public Event(MethodInfo eventMethodHandler, EventAttribute eventProperties)
    {
        EventMethodHandler = eventMethodHandler;
        EventProperties = eventProperties;
    }

    public MethodInfo EventMethodHandler { get; } 
    public EventAttribute EventProperties { get; } 
}