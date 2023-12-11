using System.Reflection;

namespace VintageStoryAPI.Addons.Common;

public interface IParser<TReturn>
{
    IEnumerable<TReturn> Parse(Assembly assembly);
}