using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Builders.ChatCommand;
using VintageStoryAPI.Addons.CommandHandler.Common.Models;
using VintageStoryAPI.Addons.CommandHandler.Invokers;

namespace VintageStoryAPI.Addons.CommandHandler.Factories;

internal class ChatCommandFactory<TApi> where TApi : ICoreAPI
{
    private readonly TApi _api;
    private readonly string _commandErrorMessage;
    private readonly IInstanceInvoker _instanceInvoker;
    private readonly ParsedInstanceFactory _parsedInstanceFactory;

    public ChatCommandFactory(ParsedInstanceFactory parsedInstanceFactory, IInstanceInvoker instanceInvoker,
        string commandErrorMessage, TApi api)
    {
        _parsedInstanceFactory = parsedInstanceFactory;
        _instanceInvoker = instanceInvoker;
        _commandErrorMessage = commandErrorMessage;
        _api = api;
    }


    public IChatCommand Create(Command<TApi> command)
    {
        var builder = ChatCommandBuilder<TApi>
            .CreateBuilder(_parsedInstanceFactory, _instanceInvoker, _commandErrorMessage, _api)
            .CreateWithName(command.Properties.Name)
            .AddProperties(command);
        if (command.PreConditions is not null) builder.AddPreConditions(command.PreConditions);
        if (command.SubCommands is not null) builder.AddSubCommands(command.SubCommands);
        return builder.Build();
    }
}