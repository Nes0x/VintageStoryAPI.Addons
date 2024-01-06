using System.Reflection;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

public interface ICommandsParser<TReturn>
{
    IEnumerable<TReturn> ParseAll(Assembly assembly);
}