using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

[AttributeUsage(AttributeTargets.Method)]
public abstract class PreConditionAttribute<T> : Attribute where T : ICoreAPI
{
    public TextCommandCallingArgs Context { get; internal set; }
    public abstract TextCommandResult Handle(T api);
}