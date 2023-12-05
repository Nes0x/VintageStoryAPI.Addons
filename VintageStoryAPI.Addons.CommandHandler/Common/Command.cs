using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

internal class Command<T> where T : ICoreAPI
{
    public Command(CommandAttribute<T> commandProperties, MethodInfo commandHandlerMethod)
    {
        CommandProperties = commandProperties;
        CommandHandlerMethod = commandHandlerMethod;
    }


    public CommandAttribute<T> CommandProperties { get; }
    public MethodInfo CommandHandlerMethod { get; }
    public ICommandArgumentParser[]? CommandParameters { get; init; }
    public MethodInfo[]? PreConditionMethods { get; init; }
    public Command<T>[]? SubCommands { get; init; }
}