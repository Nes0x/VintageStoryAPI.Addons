using System.Reflection;

namespace VintageStoryAPI.Addons.Common;

public interface IRegistrable
{
    void RegisterAll(Assembly assembly);
}