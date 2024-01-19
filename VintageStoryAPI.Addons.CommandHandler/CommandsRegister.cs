using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters.Validators;
using VintageStoryAPI.Addons.CommandHandler.Common.Models;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.CommandHandler.Factories;
using VintageStoryAPI.Addons.CommandHandler.Invokers;
using VintageStoryAPI.Addons.CommandHandler.Parsers;
using VintageStoryAPI.Addons.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.CommandHandler;

public class CommandsRegister<TApi> : IRegistrable where TApi : ICoreAPI
{
    private readonly ChatCommandFactory<TApi> _chatCommandFactory;
    private readonly ICommandsParser<Command<TApi>> _commandsParser;

    public CommandsRegister(TApi api, ExtendedCommandArgumentParser? commandArgumentParser = null,
        string commandErrorMessage = "Error: {0}", IServiceProvider? provider = null)
    {
        commandArgumentParser ??= new ExtendedCommandArgumentParser(api);
        _commandsParser = new CommandsParser<TApi>(new CommandParametersParser(commandArgumentParser,
            new CommandParametersValidator()));
        _chatCommandFactory = new ChatCommandFactory<TApi>(
            new ParsedInstanceFactory(new CommandArgumentsParser(),
                new InstanceFactory(new InstanceCreator(), provider)), new InstanceInvoker(), commandErrorMessage, api);
    }

    public void RegisterAll(Assembly assembly)
    {
        var commands = _commandsParser.ParseAll(assembly);
        foreach (var command in commands) _chatCommandFactory.Create(command);
    }
}