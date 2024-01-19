using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

[AttributeUsage(AttributeTargets.Method)]
public abstract class PreConditionAttribute<T> : Attribute, IContext where T : ICoreAPI
{
    public TextCommandCallingArgs Context { get; set; }
    public abstract TextCommandResult Handle();
}