using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal interface ICommandParametersParser<T> where T : ICoreAPI
{
    IEnumerable<ICommandArgumentParser> GetCommandParametersFromParameters(IEnumerable<ParameterInfo> parameters);
}