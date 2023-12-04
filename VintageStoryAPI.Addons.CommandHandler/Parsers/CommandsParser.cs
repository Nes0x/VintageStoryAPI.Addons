using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;
using VintageStoryAPI.Addons.Common.Extensions;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandsParser : ICommandsParser
{
    private readonly ICommandParametersParser _commandParametersParser;

    public CommandsParser(ICommandParametersParser commandParametersParser)
    {
        _commandParametersParser = commandParametersParser;
    }

    public IEnumerable<Command> GetCommandsFromAssembly<T>(Assembly assembly) where T : ICoreAPI
    {
        var commandMethods = assembly
            .GetSpecificMethodsFromTypes<CommandModule>(method => 
                method.GetCustomAttribute(typeof(CommandAttribute<T>), true) is not null
                && method.GetCustomAttribute(typeof(SubCommandAttribute), true) is null);
        var commands = commandMethods.Select(GetCommand<T>);
        return commands;
    }

    private Command GetCommand<T>(MethodInfo commandMethod) where T : ICoreAPI
    {
        var commandAttribute = commandMethod.GetCustomAttribute<CommandAttribute<T>>()!;
        var methodParameters = commandMethod.GetParameters().Where(parameter =>
            parameter.GetCustomAttribute(typeof(CommandParameterAttribute), true) is not null).AsEnumerable();
        var commandParameters = _commandParametersParser.GetCommandParametersFromParameters(
            methodParameters.Where(methodParameter =>
                !methodParameter.ParameterType.IsAssignableTo(typeof(ICoreAPI))));
        return new Command(commandAttribute.Name, commandMethod, commandMethod.DeclaringType!, new CommandProperties
        {
            Description = commandAttribute.Description,
            Aliases = commandAttribute.Aliases,
            Examples = commandAttribute.Examples,
            AdditionalInformation = commandAttribute.AdditionalInformation,
            RootAlias = commandAttribute.RootAlias,
            Privilege = commandAttribute.Privilege,
            RequiredPlayer = commandAttribute._requiredPlayer
        })
        {
            CommandParameters = commandParameters.ToArray(),
            PreConditionMethods = commandMethod.GetCustomAttributes()
                .Where(attribute => attribute.GetType().IsAssignableTo(typeof(PreConditionAttribute<T>)))
                .Select(attribute => attribute.GetType().GetMethod("Handle")!)
                .ToArray(),
            SubCommands = commandMethod.DeclaringType!.GetSpecificMethodsFromType(method =>
            {
                if (method.GetCustomAttribute(typeof(SubCommandAttribute), true) is null 
                    || method.GetCustomAttribute(typeof(CommandAttribute<T>), true) is null) return false;
                var attribute = method.GetCustomAttribute<SubCommandAttribute>()!;
                return attribute.BaseCommandName == commandAttribute.Name;
            }).Select(GetCommand<T>).ToArray()
        };

    }
}