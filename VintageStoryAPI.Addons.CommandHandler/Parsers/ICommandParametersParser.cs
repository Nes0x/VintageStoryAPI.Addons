using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal interface ICommandParametersParser
{
    IEnumerable<ICommandArgumentParser> Parse(IEnumerable<ParameterInfo> parameters);
}