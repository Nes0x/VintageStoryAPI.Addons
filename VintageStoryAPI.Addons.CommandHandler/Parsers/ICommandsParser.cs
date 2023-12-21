using System.Reflection;

namespace VintageStoryAPI.Addons.Common;

public interface ICommandsParser<TReturn>
{
    IEnumerable<TReturn> Parse(Assembly assembly);
}