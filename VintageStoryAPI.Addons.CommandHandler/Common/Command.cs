using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

internal class Command
{
    public Command(string name, MethodInfo commandHandlerMethod, Type type, CommandProperties commandProperties)
    {
        Name = name;
        CommandHandlerMethod = commandHandlerMethod;
        Type = type;
        CommandProperties = commandProperties;
    }

    public string Name { get; }
    public MethodInfo CommandHandlerMethod { get; }
    public Type Type { get; }
    public CommandProperties CommandProperties { get; }
    public ICommandArgumentParser[]? CommandParameters { get; init; }
    public MethodInfo[]? PreConditionMethods { get; init; }
    public Command[]? SubCommands { get; init; }
}