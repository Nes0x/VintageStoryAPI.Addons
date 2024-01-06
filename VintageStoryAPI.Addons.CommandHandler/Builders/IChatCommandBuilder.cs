using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Builders;

internal interface IChatCommandBuilder<TApi> where TApi : ICoreAPI
{
    IChatCommand Build(Command<TApi> command);
}