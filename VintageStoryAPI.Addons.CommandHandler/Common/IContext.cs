using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

public interface IContext
{
    public TextCommandCallingArgs Context { get; internal set; }
}