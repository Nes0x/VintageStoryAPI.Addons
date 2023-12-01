using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandsParser<T> : ICommandsParser<T> where T : ICoreAPI
{
    private readonly ICommandParametersParser<T> _commandParametersParser;

    public CommandsParser(ICommandParametersParser<T> commandParametersParser)
    {
        _commandParametersParser = commandParametersParser;
    }

    public IEnumerable<Command<T>> GetCommandsFromAssembly(Assembly assembly)
    {
        var commandModules = assembly.GetTypes().Where(type =>
            type.IsAssignableTo(typeof(CommandModule)) && !type.IsAbstract);
        var commandMethods = commandModules.SelectMany(type =>
            type.GetMethods()
                .Where(method => method.GetCustomAttribute(typeof(CommandAttribute<T>), true) is not null));
        var commands = commandMethods.Select(method =>
        {
            var attribute = method.GetCustomAttribute<CommandAttribute<T>>()!;
            var methodParameters = method.GetParameters().Where(parameter =>
                parameter.GetCustomAttribute(typeof(CommandParameterAttribute), true) is not null).AsEnumerable();
            var commandParameters = _commandParametersParser.GetCommandParametersFromParameters(methodParameters.Where(methodParameter => !methodParameter.ParameterType.IsAssignableTo(typeof(ICoreAPI))));
            return new Command<T>(attribute.Name, method, method.DeclaringType!)
            {
                Description = attribute.Description,
                Aliases = attribute.Aliases,
                Examples = attribute.Examples,
                AdditionalInformation = attribute.AdditionalInformation,
                RootAlias = attribute.RootAlias,
                Privilege = attribute.Privilege,
                RequiredPlayer = attribute._requiredPlayer,
                CommandParameters = commandParameters.ToArray()
            };
        });
        return commands;
    }
}