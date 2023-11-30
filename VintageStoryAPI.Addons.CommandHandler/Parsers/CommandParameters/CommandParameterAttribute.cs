using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers.CommandParameters;

[AttributeUsage(AttributeTargets.Parameter)]
public abstract class CommandParameterAttribute : Attribute
{
    [ArgsParser] public abstract string Name { get; }
    public abstract string MethodName { get; }
}