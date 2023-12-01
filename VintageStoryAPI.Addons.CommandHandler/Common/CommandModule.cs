using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

public abstract class CommandModule
{
    #nullable disable
    public TextCommandCallingArgs Context { get; internal set; }
}