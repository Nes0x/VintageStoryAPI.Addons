using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.CommandHandler.Invokers;

namespace VintageStoryAPI.Addons.CommandHandler.Builders;

internal class ChatCommandBuilder<TApi> : IChatCommandBuilder<TApi> where TApi : ICoreAPI
{
    private readonly ICommandInvoker _commandInvoker;
    private readonly string _commandErrorMessage;
    private readonly TApi _api;
    private readonly IServiceProvider? _provider;

    public ChatCommandBuilder(ICommandInvoker commandInvoker, string commandErrorMessage, TApi api, IServiceProvider? provider)
    {
        _commandInvoker = commandInvoker;
        _commandErrorMessage = commandErrorMessage;
        _api = api;
        _provider = provider;
    }

    public IChatCommand Build(Command<TApi> command)
    {
        var apiCommand = _api.ChatCommands.Create(command.Properties.Name);
        AddProperties(command, apiCommand);
        if (command.PreConditions is not null) AddPreconditions(command, apiCommand);
        if (command.SubCommands is not null) AddSubCommands(command, apiCommand);
        return apiCommand;
    }

    private void AddPreconditions(Command<TApi> command, IChatCommand apiCommand)
    {
        foreach (var commandPreCondition in command.PreConditions!)
            apiCommand.WithPreCondition(args => Handle(commandPreCondition, args));
    }

    private void AddSubCommands(Command<TApi> command, IChatCommand apiCommand)
    {
        foreach (var subCommand in command.SubCommands!)
        {
            var subApiCommand = apiCommand.BeginSubCommand(subCommand.Properties.Name);
            AddProperties(subCommand, subApiCommand);
            subApiCommand.EndSubCommand();
        }
    }
    
    private void AddProperties(Command<TApi> command, IChatCommand apiCommand)
    {
        var properties = command.Properties;
        apiCommand
            .WithNullableDescription(properties.Description)
            .WithNullableAlias(properties.Aliases)
            .WithNullableExamples(properties.Examples)
            .WithNullableAdditionalInformation(properties.AdditionalInformation)
            .WithNullableRootAlias(properties.RootAlias)
            .RequiresNullablePlayer(properties.RequiredPlayer)
            .WithNullableArgs(command.Parameters)
            .RequiresNullablePrivilege(properties.Privilege)
            .HandleWith(args => Handle(command.Handler, args));
    }

    private TextCommandResult Handle(MethodInfo handler, TextCommandCallingArgs args)
    {
        var result = _commandInvoker.Invoke(handler, args, _api, _provider);
        return result.IsError
            ? TextCommandResult.Error(string.Format(_commandErrorMessage, result.ErrorMessage))
            : result.Result!;
    }
    
}