using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.Models;

namespace VintageStoryAPI.Addons.CommandHandler.Invokers;

internal interface IInstanceInvoker
{
    InvokeResult Invoke<TApi, TInstance>(ParsedInstance<TInstance> parsedInstance, TApi api)
        where TApi : ICoreAPI where TInstance : class, IContext;
}