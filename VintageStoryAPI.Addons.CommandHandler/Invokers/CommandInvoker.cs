using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Parsers;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.CommandHandler.Invokers;

internal class CommandInvoker : ICommandInvoker
{
    private readonly ICommandArgumentsParser _commandArgumentsParser;
    private readonly IInstanceCreator _instanceCreator;

    public CommandInvoker(IInstanceCreator instanceCreator, ICommandArgumentsParser commandArgumentsParser)
    {
        _instanceCreator = instanceCreator;
        _commandArgumentsParser = commandArgumentsParser;
    }

    public CommandInvokeResult Invoke<TApi>(MethodInfo method, TextCommandCallingArgs context, TApi api,
        IServiceProvider? provider = null) where TApi : ICoreAPI
    {
        var commandType = method.DeclaringType!;
        var commandInstance = _instanceCreator.Create(commandType, provider)!;
        var arguments = _commandArgumentsParser
            .ParseAll(context.Parsers, method.GetParameters());
        commandType.GetProperty("Context")!.SetValue(commandInstance, context);
        try
        {
            var result = (TextCommandResult)method.Invoke(commandInstance, arguments.ToArray())!;
            return new CommandInvokeResult
            {
                Result = result
            };
        }
        catch (Exception exception)
        {
            api.Logger.Error(exception);
            return new CommandInvokeResult
            {
                IsError = true,
                ErrorMessage = exception.Message
            };
        }
    }
}