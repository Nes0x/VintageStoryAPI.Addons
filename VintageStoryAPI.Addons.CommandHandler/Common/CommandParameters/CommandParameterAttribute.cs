namespace VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;

[AttributeUsage(AttributeTargets.Parameter)]
public abstract class CommandParameterAttribute : Attribute
{
    [ArgsParser] public abstract string Name { get; }
    public abstract string MethodName { get; }
}