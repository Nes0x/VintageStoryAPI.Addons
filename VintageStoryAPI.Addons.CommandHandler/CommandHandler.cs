using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Creators;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.CommandHandler.Parsers;

namespace VintageStoryAPI.Addons.CommandHandler;

public class CommandHandler<T> : ICommandHandler<T> where T : ICoreAPI
{
    private readonly T _api;
    private readonly ICoreAPI _coreApi;
    private readonly IServiceProvider? _provider;

    public CommandHandler(T api, ICoreAPI coreApi, IServiceProvider? provider = null)
    {
        _api = api;
        _coreApi = coreApi;
        _provider = provider;
    }

    public void RegisterCommands()
    {
        ICommandsParser<T> commandsParser = new CommandsParser<T>(new ArgumentsParser<T>(new CommandArgumentParsers(_coreApi)));
        IInstancesCreator instancesCreator = new InstancesCreator(_provider);
        var commands = commandsParser.GetCommandsFromAssembly(Assembly.GetCallingAssembly()).Where(command => command.GetType().GenericTypeArguments.First() == typeof(T));
        foreach (var command in commands)
        {
            _api.ChatCommands
                .Create(command.Name)
                .WithNullableDescription(command.Description)
                .WithNullableAlias(command.Aliases)
                .WithNullableExamples(command.Examples)
                .WithNullableAdditionalInformation(command.AdditionalInformation)
                .WithNullableRootAlias(command.RootAlias)
                .RequiresNullablePlayer(command.RequiredPlayer)
                .WithNullableArgs(command.CommandArguments)
                .RequiresNullablePrivilege(command.Privilege)
                .HandleWith(args =>
                {
                    var type = command.Type;
                    var instance = instancesCreator.CreateInstance(command.Type);
                    var parameters = args.Parsers.Select(parser => parser.GetValue());
                    type.GetProperty("Context")!.SetValue(instance, args);
                    try
                    {
                        return (TextCommandResult)command.CommandMethod.Invoke(instance, parameters.ToArray())!;
                    }
                    catch (Exception e)
                    {
                        return TextCommandResult.Error($"Error: {e.Message}");
                    }
                });
        }

    }
}