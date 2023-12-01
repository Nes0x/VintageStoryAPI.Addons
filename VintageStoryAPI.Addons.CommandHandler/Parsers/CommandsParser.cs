using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandsParser<T> : ICommandsParser<T> where T : ICoreAPI
{
    private readonly IArgumentsParser<T> _argumentsParser;

    public CommandsParser(IArgumentsParser<T> argumentsParser)
    {
        _argumentsParser = argumentsParser;
    }

    public IEnumerable<Command<T>> GetCommandsFromAssembly(Assembly assembly)
    {
        var targetType = typeof(CommandModule);
        var types = assembly.GetTypes().Where(type =>
            type.IsAssignableTo(targetType) && !type.IsAbstract);
        var methods = types.SelectMany(type =>
            type.GetMethods().Where(method => method.GetCustomAttribute(typeof(CommandAttribute<T>), true) is not null));
        var commands = methods.Select(method =>
        {
            var attribute = method.GetCustomAttribute<CommandAttribute<T>>()!;
            var methodParameters = method.GetParameters().Where(parameter =>
                parameter.GetCustomAttribute(typeof(CommandParameterAttribute), true) is not null).AsEnumerable();
            var commandArguments = _argumentsParser.GetArgumentsFromParameters(methodParameters);
            return new Command<T>(attribute.Name, method, method.DeclaringType!)
            {
                Description = attribute.Description,
                Aliases = attribute.Aliases,
                Examples = attribute.Examples,
                AdditionalInformation = attribute.AdditionalInformation,
                RootAlias = attribute.RootAlias,
                Privilege = attribute.Privilege,
                RequiredPlayer = attribute._requiredPlayer,
                CommandArguments = commandArguments.ToArray()
            };
        });
        return commands;
    }
}