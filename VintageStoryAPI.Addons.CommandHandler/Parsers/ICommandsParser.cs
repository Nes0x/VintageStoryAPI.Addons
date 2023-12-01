using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal interface ICommandsParser<T> where T : ICoreAPI
{
    IEnumerable<Command<T>> GetCommandsFromAssembly(Assembly assembly);
}