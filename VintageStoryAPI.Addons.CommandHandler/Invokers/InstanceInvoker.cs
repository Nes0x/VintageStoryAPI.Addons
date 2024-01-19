using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Invokers;

internal class InstanceInvoker : IInstanceInvoker
{
    public InvokeResult Invoke<TApi, TInstance>(ParsedInstance<TInstance> parsedInstance, TApi api)
        where TApi : ICoreAPI where TInstance : class, IContext
    {
        try
        {
            var result = (TextCommandResult)parsedInstance
                .Handler
                .Invoke(parsedInstance.Instance, parsedInstance.Arguments.ToArray())!;
            return new InvokeResult
            {
                Result = result
            };
        }
        catch (Exception exception)
        {
            api.Logger.Error(exception);
            return new InvokeResult
            {
                IsError = true,
                ErrorMessage = exception.Message
            };
        }
    }

}