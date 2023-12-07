using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

internal class Command<TApi> where TApi : ICoreAPI
{
    public Command(CommandAttribute<TApi> commandProperties, MethodInfo commandHandlerMethod)
    {
        CommandProperties = commandProperties;
        CommandHandlerMethod = commandHandlerMethod;
    }


    public CommandAttribute<TApi> CommandProperties { get; }
    public MethodInfo CommandHandlerMethod { get; }
    public ICommandArgumentParser[]? CommandParameters { get; init; }
    public MethodInfo[]? PreConditionMethods { get; init; }
    public Command<TApi>[]? SubCommands { get; init; }
}