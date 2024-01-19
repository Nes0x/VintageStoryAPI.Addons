using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common.Models;

public abstract class CommandModule : IContext
{
    public TextCommandCallingArgs Context { get; set; }
}