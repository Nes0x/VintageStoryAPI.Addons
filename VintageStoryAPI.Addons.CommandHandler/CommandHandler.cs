using System.Reflection;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.CommandHandler.Parsers;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.CommandHandler;

public class CommandHandler<T> : ICommandHandler<T> where T : ICoreAPI
{
    private readonly T _api;
    private readonly IServiceProvider? _provider;

    public CommandHandler(T api, IServiceProvider? provider = null)
    {
        _api = api;
        _provider = provider;
    }

    public void RegisterCommands()
    {
        ICommandsParser<T> commandsParser =
            new CommandsParser<T>(new CommandParametersParser<T>(new ExtendedCommandArgumentParser(_api)));
        IInstancesCreator instancesCreator = new InstancesCreator();
        var commands = commandsParser.GetCommandsFromAssembly(Assembly.GetCallingAssembly());
        foreach (var command in commands)
            _api.ChatCommands
                .Create(command.Name)
                .WithNullableDescription(command.Description)
                .WithNullableAlias(command.Aliases)
                .WithNullableExamples(command.Examples)
                .WithNullableAdditionalInformation(command.AdditionalInformation)
                .WithNullableRootAlias(command.RootAlias)
                .RequiresNullablePlayer(command.RequiredPlayer)
                .WithNullableArgs(command.CommandParameters)
                .RequiresNullablePrivilege(command.Privilege)
                .HandleWith(args =>
                {
                    var type = command.Type;
                    var instance = instancesCreator.CreateInstance(command.Type, _provider);
                    var arguments = args.Parsers.Select((parser, index) =>
                        {
                            var value = parser.GetValue();
                            if (value is not null) return value;
                            var parameter = command.CommandMethod.GetParameters().ElementAt(index + 1);
                            if (parameter.HasDefaultValue) value = parameter.DefaultValue;

                            return value;
                        })
                        .Prepend(_api);
                    type.GetProperty("Context")!.SetValue(instance, args);
                    try
                    {
                        return (TextCommandResult)command.CommandMethod.Invoke(instance, arguments.ToArray())!;
                    }
                    catch (Exception e)
                    {
                        return TextCommandResult.Error($"Error: {e.Message}");
                    }
                });
    }
    
    
}