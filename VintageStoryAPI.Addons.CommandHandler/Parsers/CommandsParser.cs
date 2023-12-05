using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;
using VintageStoryAPI.Addons.Common;
using VintageStoryAPI.Addons.Common.Extensions;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandsParser<TReturn> : IParser<Command<TReturn>> where TReturn : ICoreAPI
{
    private readonly ICommandParametersParser _commandParametersParser;

    public CommandsParser(ICommandParametersParser commandParametersParser)
    {
        _commandParametersParser = commandParametersParser;
    }

    public IEnumerable<Command<TReturn>> Parse(Assembly assembly) 
    {
        var commandMethods = assembly
            .GetSpecificMethodsFromTypes<CommandModule>(method => 
                method.GetCustomAttribute(typeof(CommandAttribute<TReturn>), true) is not null
                && method.GetCustomAttribute(typeof(SubCommandAttribute), true) is null);
        var commands = commandMethods.Select(GetCommand);
        return commands;
    }

    private Command<TReturn> GetCommand(MethodInfo commandMethod)
    {
        var commandAttribute = commandMethod.GetCustomAttribute<CommandAttribute<TReturn>>()!;
        var methodParameters = commandMethod.GetParameters().Where(parameter =>
            parameter.GetCustomAttribute(typeof(CommandParameterAttribute), true) is not null).AsEnumerable();
        var commandParameters = _commandParametersParser.Parse(
            methodParameters.Where(methodParameter =>
                !methodParameter.ParameterType.IsAssignableTo(typeof(ICoreAPI))));
        return new Command<TReturn>(commandAttribute, commandMethod)
        {
            CommandParameters = commandParameters.ToArray(),
            PreConditionMethods = commandMethod.GetCustomAttributes()
                .Where(attribute => attribute.GetType().IsAssignableTo(typeof(PreConditionAttribute<TReturn>)))
                .Select(attribute => attribute.GetType().GetMethod("Handle")!)
                .ToArray(),
            SubCommands = commandMethod.DeclaringType!.GetSpecificMethodsFromType(method =>
            {
                if (method.GetCustomAttribute(typeof(SubCommandAttribute), true) is null 
                    || method.GetCustomAttribute(typeof(CommandAttribute<TReturn>), true) is null) return false;
                var attribute = method.GetCustomAttribute<SubCommandAttribute>()!;
                return attribute.BaseCommandName == commandAttribute.Name;
            }).Select(GetCommand).ToArray()
        };

    }
}