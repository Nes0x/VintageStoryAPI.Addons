using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal interface ICommandsParser
{
    IEnumerable<Command> GetCommandsFromAssembly<T>(Assembly assembly) where T : ICoreAPI;
}