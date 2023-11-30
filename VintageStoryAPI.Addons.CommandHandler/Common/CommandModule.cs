using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

public abstract class CommandModule
{
    public TextCommandCallingArgs Context { get; internal set; }
}