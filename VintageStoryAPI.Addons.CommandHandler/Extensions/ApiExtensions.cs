using System.Reflection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Creators;
using VintageStoryAPI.Addons.CommandHandler.Parsers;

namespace VintageStoryAPI.Addons.CommandHandler.Extensions;

public static class ApiExtensions
{
    public static ICoreClientAPI RegisterCommands(this ICoreClientAPI api, ICoreAPI coreApi,
        IServiceProvider? provider = null)
    {
        ICommandsParser commandsParser = new CommandsParser(new ArgumentsParser(new CommandArgumentParsers(coreApi)));
        IInstancesCreator instancesCreator = new InstancesCreator();
        var commands = commandsParser.GetCommandsFromAssembly(Assembly.GetCallingAssembly());
        foreach (var command in commands)
            api.ChatCommands
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
                    var instance = instancesCreator.CreateInstance(command.Type, provider);
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
        return api;
    }
}