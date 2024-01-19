using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Invokers;

internal interface IInstanceInvoker
{
    InvokeResult Invoke<TApi, TInstance>(ParsedInstance<TInstance> parsedInstance, TApi api)
        where TApi : ICoreAPI where TInstance : class, IContext;
}