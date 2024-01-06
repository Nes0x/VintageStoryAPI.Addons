using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

internal class Command<TApi> where TApi : ICoreAPI
{
    public Command(CommandAttribute<TApi> properties, MethodInfo handler)
    {
        Properties = properties;
        Handler = handler;
    }


    public CommandAttribute<TApi> Properties { get; }
    public MethodInfo Handler { get; }
    public ICommandArgumentParser[]? Parameters { get; init; }
    public MethodInfo[]? PreConditions { get; init; }
    public Command<TApi>[]? SubCommands { get; init; }
}