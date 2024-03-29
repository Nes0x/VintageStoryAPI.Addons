﻿using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.Models;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.CommandHandler.Factories;
using VintageStoryAPI.Addons.CommandHandler.Invokers;

namespace VintageStoryAPI.Addons.CommandHandler.Builders.ChatCommand;

#nullable disable
internal class ChatCommandBuilder<TApi> : ISpecificationChatCommandBuilder<TApi>, IChatCommandBuilder<TApi>
    where TApi : ICoreAPI
{
    private readonly TApi _api;
    private readonly string _commandErrorMessage;
    private readonly IInstanceInvoker _instanceInvoker;
    private readonly ParsedInstanceFactory _parsedInstanceFactory;
    private IChatCommand _apiCommand;

    private ChatCommandBuilder(ParsedInstanceFactory parsedInstanceFactory, IInstanceInvoker instanceInvoker,
        string commandErrorMessage, TApi api)
    {
        _parsedInstanceFactory = parsedInstanceFactory;
        _instanceInvoker = instanceInvoker;
        _commandErrorMessage = commandErrorMessage;
        _api = api;
    }

    public ISpecificationChatCommandBuilder<TApi> CreateWithName(string name)
    {
        _apiCommand = _api.ChatCommands.Create(name);
        return this;
    }


    public IChatCommand Build()
    {
        return _apiCommand;
    }

    public ISpecificationChatCommandBuilder<TApi> AddPreConditions(IEnumerable<MethodInfo> preConditions)
    {
        foreach (var commandPreCondition in preConditions)
            _apiCommand.WithPreCondition(args => AddHandler<PreConditionAttribute<TApi>>(commandPreCondition, args));
        return this;
    }

    public ISpecificationChatCommandBuilder<TApi> AddSubCommands(IEnumerable<Command<TApi>> subCommands)
    {
        foreach (var subCommand in subCommands)
        {
            var subApiCommand = _apiCommand.BeginSubCommand(subCommand.Properties.Name);
            AddProperties(subCommand, subApiCommand);
            subApiCommand.EndSubCommand();
        }

        return this;
    }

    public ISpecificationChatCommandBuilder<TApi> AddProperties(Command<TApi> command, IChatCommand apiCommand = null)
    {
        apiCommand ??= _apiCommand;
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
            .HandleWith(args => AddHandler<CommandModule>(command.Handler, args));
        return this;
    }

    public static IChatCommandBuilder<TApi> CreateBuilder(ParsedInstanceFactory parsedInstanceFactory,
        IInstanceInvoker instanceInvoker,
        string commandErrorMessage, TApi api)
    {
        return new ChatCommandBuilder<TApi>(parsedInstanceFactory, instanceInvoker, commandErrorMessage, api);
    }


    private TextCommandResult AddHandler<TInstance>(MethodInfo handler, TextCommandCallingArgs args) where
        TInstance : class, IContext
    {
        var result = _instanceInvoker.Invoke(_parsedInstanceFactory.Create<TInstance>(handler, args), _api);
        return result.IsError
            ? TextCommandResult.Error(string.Format(_commandErrorMessage, result.ErrorMessage))
            : result.Result;
    }
}