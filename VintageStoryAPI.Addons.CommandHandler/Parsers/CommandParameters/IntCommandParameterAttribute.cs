using VintageStoryAPI.Addons.CommandHandler.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers.CommandParameters;

public class IntCommandParameterAttribute : CommandParameterAttribute, IOptional
{
    public IntCommandParameterAttribute(string name, int defaultValue = 0, bool isOptional = false)
    {
        Name = name;
        DefaultValue = defaultValue;
        IsOptional = isOptional;
    }

    public override string Name { get; }
    [OptionalArgsParser] public int DefaultValue { get; }
    public string OptionalMethodName => "OptionalInt";
    public override string MethodName => "Int";
    public bool IsOptional { get; }
}