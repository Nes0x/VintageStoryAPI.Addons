using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.Common;

public interface IHandler
{
    void RegisterAll(Assembly assembly);
}