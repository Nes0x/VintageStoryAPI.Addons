﻿using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal interface ICommandArgumentsParser
{
    IEnumerable<object?> ParseAll(IEnumerable<ICommandArgumentParser> parsers,
        IEnumerable<ParameterInfo> parameters);
}