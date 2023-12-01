using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler;

public interface ICommandHandler<T> where T : ICoreAPI
{
    void RegisterCommands();
}