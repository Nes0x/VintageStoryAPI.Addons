using System.Reflection;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal interface ICommandsParser
{
    IEnumerable<Command> GetCommandsFromAssembly(Assembly assembly);
}