using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Parsers;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.CommandHandler;

internal class CommandMethodInvoker : ICommandMethodInvoker
{
    private readonly ICommandArgumentsParser _commandArgumentsParser;
    private readonly IInstancesCreator _instancesCreator;

    public CommandMethodInvoker(IInstancesCreator instancesCreator, ICommandArgumentsParser commandArgumentsParser)
    {
        _instancesCreator = instancesCreator;
        _commandArgumentsParser = commandArgumentsParser;
    }

    public CommandMethodInvokerResult Invoke<T>(MethodInfo method, TextCommandCallingArgs context, T api,
        IServiceProvider? provider = null) where T : ICoreAPI
    {
        var type = method.DeclaringType!;
        var instance = _instancesCreator.CreateInstance(type, provider)!;
        var arguments = _commandArgumentsParser
            .GetArgumentsFromParsers(context.Parsers, method.GetParameters())
            .Prepend(api);
        type.GetProperty("Context")!.SetValue(instance, context);
        try
        {
            var result = (TextCommandResult)method.Invoke(instance, arguments.ToArray())!;
            return new CommandMethodInvokerResult
            {
                Result = result
            };
        }
        catch (Exception exception)
        {
            return new CommandMethodInvokerResult
            {
                IsError = true,
                ErrorMessage = exception.Message
            };
        }
    }
}