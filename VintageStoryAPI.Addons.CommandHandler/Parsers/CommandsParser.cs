using System.Reflection;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Parsers.CommandParameters;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandsParser : ICommandsParser
{
    private readonly IArgumentsParser _argumentsParser;

    public CommandsParser(IArgumentsParser argumentsParser)
    {
        _argumentsParser = argumentsParser;
    }

    public IEnumerable<Command> GetCommandsFromAssembly(Assembly assembly)
    {
        var targetType = typeof(CommandModule);
        var types = assembly.GetTypes().Where(type =>
            type.IsAssignableTo(targetType) && !type.IsAbstract);
        var methods = types.SelectMany(type =>
            type.GetMethods().Where(method => method.GetCustomAttribute(typeof(CommandAttribute), true) is not null));
        var commands = methods.Select(method =>
        {
            var attribute = method.GetCustomAttribute<CommandAttribute>()!;
            var methodParameters = method.GetParameters().Where(parameter =>
                parameter.GetCustomAttribute(typeof(CommandParameterAttribute), true) is not null).AsEnumerable();
            var commandArguments = _argumentsParser.GetArgumentsFromParameters(methodParameters);
            return new Command(attribute.Name, method, method.DeclaringType!)
            {
                Description = attribute.Description,
                Aliases = attribute.Aliases,
                Examples = attribute.Examples,
                AdditionalInformation = attribute.AdditionalInformation,
                RootAlias = attribute.RootAlias,
                Privilege = attribute.Privilege,
                RequiredPlayer = attribute._requiredPlayer,
                CommandMethod = method,
                CommandArguments = commandArguments.ToArray()
            };
        });
        return commands;
    }
}