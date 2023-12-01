using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler;

public interface ICommandHandler<T> where T : ICoreAPI
{
    void RegisterCommands();
}