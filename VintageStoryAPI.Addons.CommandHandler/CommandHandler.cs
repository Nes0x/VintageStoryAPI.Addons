using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters.Validators;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.CommandHandler.Invokers;
using VintageStoryAPI.Addons.CommandHandler.Parsers;
using VintageStoryAPI.Addons.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.CommandHandler;

public class CommandHandler<TApi> : IHandler<TApi> where TApi : ICoreAPI
{
    private readonly TApi _api;
    private readonly string _commandErrorMessage;
    private readonly ICommandMethodInvoker _commandMethodInvoker;
    private readonly IParser<Command<TApi>> _commandsParser;
    private readonly IServiceProvider? _provider;

    public CommandHandler(TApi api, ExtendedCommandArgumentParser? commandArgumentParser = null, string commandErrorMessage = "Error: {0}", IServiceProvider? provider = null)
    {
        _api = api;
        _provider = provider;
        commandArgumentParser ??= new ExtendedCommandArgumentParser(_api);
        _commandsParser = new CommandsParser<TApi>(new CommandParametersParser(commandArgumentParser,
            new CommandParametersValidator()));
        _commandMethodInvoker = new CommandMethodInvoker(new InstancesCreator(), new CommandArgumentsParser());
        _commandErrorMessage = commandErrorMessage;
    }

    public void RegisterAll(Assembly assembly)
    {
        var commands = _commandsParser.Parse(assembly);
        foreach (var command in commands)
        {
            var chatCommand = _api.ChatCommands.Create(command.CommandProperties.Name);
            AddCommandProperties(command, chatCommand);
            if (command.PreConditionMethods is null) continue;
            foreach (var commandPreCondition in command.PreConditionMethods)
                chatCommand.WithPreCondition(args => Handle(commandPreCondition, args));
            if (command.SubCommands is null) continue;
            foreach (var subCommand in command.SubCommands)
            { 
                var subChatCommand = chatCommand.BeginSubCommand(subCommand.CommandProperties.Name);
                AddCommandProperties(subCommand, subChatCommand);
                subChatCommand.EndSubCommand();
            }
        }
    }

    private void AddCommandProperties(Command<TApi> command, IChatCommand chatCommand)
    {
        var commandProperties = command.CommandProperties;
        chatCommand
            .WithNullableDescription(commandProperties.Description)
            .WithNullableAlias(commandProperties.Aliases)
            .WithNullableExamples(commandProperties.Examples)
            .WithNullableAdditionalInformation(commandProperties.AdditionalInformation)
            .WithNullableRootAlias(commandProperties.RootAlias)
            .RequiresNullablePlayer(commandProperties.RequiredPlayer)
            .WithNullableArgs(command.CommandParameters)
            .RequiresNullablePrivilege(commandProperties.Privilege)
            .HandleWith(args => Handle(command.CommandHandlerMethod, args));
    }

    private TextCommandResult Handle(MethodInfo method, TextCommandCallingArgs args)
    {
        var result = _commandMethodInvoker.Invoke(method, args, _api, _provider);
        return result.IsError
            ? TextCommandResult.Error(string.Format(_commandErrorMessage, result.ErrorMessage))
            : result.Result!;
    }
}