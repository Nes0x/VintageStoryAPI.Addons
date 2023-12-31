﻿using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Invokers;

internal interface ICommandInvoker
{
    CommandInvokeResult Invoke<T>(MethodInfo method, TextCommandCallingArgs context, T api,
        IServiceProvider? provider = null)
        where T : ICoreAPI;
}