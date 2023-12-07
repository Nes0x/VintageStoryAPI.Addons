using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Common;

[AttributeUsage(AttributeTargets.Method)]
public class EventAttribute<TApi> : Attribute where TApi : ICoreAPI
{
    public EventAttribute(EventType eventType)
    {
        EventType = eventType;
    }

    public EventType EventType { get; }
}