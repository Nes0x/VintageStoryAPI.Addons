using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.Models;

namespace VintageStoryAPI.Addons.CommandHandler.Builders.ChatCommand;

internal interface ISpecificationChatCommandBuilder<TApi> where TApi : ICoreAPI
{
    ISpecificationChatCommandBuilder<TApi> AddPreConditions(IEnumerable<MethodInfo> preConditions);
    ISpecificationChatCommandBuilder<TApi> AddSubCommands(IEnumerable<Command<TApi>> subCommands);
    ISpecificationChatCommandBuilder<TApi> AddProperties(Command<TApi> command, IChatCommand? apiCommand = null);
    IChatCommand Build();
}