using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal interface IArgumentsParser
{
    IEnumerable<ICommandArgumentParser> GetArgumentsFromParameters(IEnumerable<ParameterInfo> parameters);
}