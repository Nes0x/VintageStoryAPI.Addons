using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.Common;

public interface IHandler<T> where T : ICoreAPI
{
    void RegisterAll(Assembly assembly);
}