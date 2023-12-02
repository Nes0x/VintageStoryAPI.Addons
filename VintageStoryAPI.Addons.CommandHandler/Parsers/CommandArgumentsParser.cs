using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandArgumentsParser : ICommandArgumentsParser
{
    public IEnumerable<object?> GetArgumentsFromParsers(IEnumerable<ICommandArgumentParser> parsers, IEnumerable<ParameterInfo> parameters)
    {
        return parsers.Select((parser, index) =>
        {
            var value = parser.GetValue();
            if (value is not null) return value;
            var parameter = parameters.ElementAt(index + 1);
            return parameter.HasDefaultValue ? parameter.DefaultValue : value;
        });
    }
}