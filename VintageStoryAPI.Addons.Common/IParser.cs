using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.Common;

public interface IParser<TReturn>
{
    IEnumerable<TReturn> Parse(Assembly assembly);
}