using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.Attributes;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;
using VintageStoryAPI.Addons.CommandHandler.Common.Models;
using VintageStoryAPI.Addons.Common.Extensions;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandsParser<TApi> : ICommandsParser<Command<TApi>> where TApi : ICoreAPI
{
    private readonly ICommandParametersParser _commandParametersParser;

    public CommandsParser(ICommandParametersParser commandParametersParser)
    {
        _commandParametersParser = commandParametersParser;
    }

    public IEnumerable<Command<TApi>> ParseAll(Assembly assembly)
    {
        var commandHandlers = assembly
            .GetSpecificMethods<CommandModule>(method =>
                method.GetCustomAttribute(typeof(CommandAttribute<TApi>), true) is not null
                && method.GetCustomAttribute(typeof(SubCommandAttribute), true) is null);
        var commands = commandHandlers.Select(Parse);
        return commands;
    }

    private Command<TApi> Parse(MethodInfo commandHandler)
    {
        var commandAttribute = commandHandler.GetCustomAttribute<CommandAttribute<TApi>>()!;
        var handlerParameters = commandHandler.GetParameters().Where(parameter =>
            parameter.GetCustomAttribute(typeof(CommandParameterAttribute), true) is not null).AsEnumerable();
        var commandParameters = _commandParametersParser.ParseAll(
            handlerParameters.Where(methodParameter =>
                !methodParameter.ParameterType.IsAssignableTo(typeof(ICoreAPI))));
        return new Command<TApi>(commandAttribute, commandHandler)
        {
            Parameters = commandParameters.ToArray(),
            PreConditions = commandHandler.GetCustomAttributes()
                .Where(attribute => attribute.GetType().IsAssignableTo(typeof(PreConditionAttribute<TApi>)))
                .Select(attribute => attribute.GetType().GetMethod("Handle")!)
                .ToArray(),
            SubCommands = commandHandler.DeclaringType!.GetSpecificMethods(method =>
            {
                if (method.GetCustomAttribute(typeof(SubCommandAttribute), true) is null
                    || method.GetCustomAttribute(typeof(CommandAttribute<TApi>), true) is null) return false;
                var attribute = method.GetCustomAttribute<SubCommandAttribute>()!;
                return attribute.BaseCommandName == commandAttribute.Name;
            }).Select(Parse).ToArray()
        };
    }
}