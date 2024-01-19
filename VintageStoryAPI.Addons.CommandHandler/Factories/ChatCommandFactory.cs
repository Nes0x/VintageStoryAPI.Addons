using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Builders;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Invokers;

namespace VintageStoryAPI.Addons.CommandHandler.Factories;

internal class ChatCommandFactory<TApi>  where TApi : ICoreAPI
{
    private readonly ParsedInstanceFactory _parsedInstanceFactory;
    private readonly IInstanceInvoker _instanceInvoker;
    private readonly string _commandErrorMessage;
    private readonly TApi _api;

    public ChatCommandFactory(ParsedInstanceFactory parsedInstanceFactory, IInstanceInvoker instanceInvoker, string commandErrorMessage, TApi api)
    {
        _parsedInstanceFactory = parsedInstanceFactory;
        _instanceInvoker = instanceInvoker;
        _commandErrorMessage = commandErrorMessage;
        _api = api;
    }


    public IChatCommand Create(Command<TApi> command)
    {
        var builder = new ChatCommandBuilder<TApi>(_parsedInstanceFactory, _instanceInvoker, _commandErrorMessage, _api);
        builder.CreateWithName(command.Properties.Name)
                .AddProperties(command);
        if (command.PreConditions is not null) builder.AddPreConditions(command.PreConditions);
        if (command.SubCommands is not null) builder.AddSubCommands(command.SubCommands);
        return builder.Build();
    }
    
}