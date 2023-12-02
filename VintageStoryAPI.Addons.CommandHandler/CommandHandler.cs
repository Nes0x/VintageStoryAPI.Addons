using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.CommandHandler.Parsers;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.CommandHandler;

public class CommandHandler<T> : ICommandHandler<T> where T : ICoreAPI
{
    private readonly T _api;
    private readonly string _commandErrorMessage;
    private readonly IServiceProvider? _provider;
    private readonly ICommandsParser _commandsParser;
    private readonly IInstancesCreator _instancesCreator = new InstancesCreator();
    private readonly ICommandArgumentsParser _commandArgumentsParser = new CommandArgumentsParser();


    public CommandHandler(T api, string commandErrorMessage = "Error: {0}", IServiceProvider? provider = null)
    {
        _api = api;
        _provider = provider;
        _commandsParser = new CommandsParser(new CommandParametersParser(new ExtendedCommandArgumentParser(_api), new CommandParametersValidator()));
        _commandErrorMessage = commandErrorMessage;
    }

    public void RegisterCommands()
    {
        var commands = _commandsParser.GetCommandsFromAssembly<T>(Assembly.GetCallingAssembly());
        foreach (var command in commands)
        {
            var commandProperties = command.CommandProperties;
            _api.ChatCommands
                .Create(command.Name)
                .WithNullableDescription(commandProperties.Description)
                .WithNullableAlias(commandProperties.Aliases)
                .WithNullableExamples(commandProperties.Examples)
                .WithNullableAdditionalInformation(commandProperties.AdditionalInformation)
                .WithNullableRootAlias(commandProperties.RootAlias)
                .RequiresNullablePlayer(commandProperties.RequiredPlayer)
                .WithNullableArgs(commandProperties.CommandParameters)
                .RequiresNullablePrivilege(commandProperties.Privilege)
                .HandleWith(args => Handle(args, command));
        }
    }

    private TextCommandResult Handle(TextCommandCallingArgs args, Command command)
    {
        var type = command.Type;
        var instance = _instancesCreator.CreateInstance(command.Type, _provider);
        var arguments = _commandArgumentsParser
            .GetArgumentsFromParsers(args.Parsers, command.CommandHandlerMethod.GetParameters())
            .Prepend(_api);
        type.GetProperty("Context")!.SetValue(instance, args);
        try
        {
            return (TextCommandResult)command.CommandHandlerMethod.Invoke(instance, arguments.ToArray())!;
        }
        catch (Exception exception)
        {
            return TextCommandResult.Error(string.Format(_commandErrorMessage, exception.Message));
        }
    }
    
    
}