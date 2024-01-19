using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Builders.ChatCommand;

internal interface IChatCommandBuilder<TApi> where TApi : ICoreAPI
{
    ISpecificationChatCommandBuilder<TApi> CreateWithName(string name);
}