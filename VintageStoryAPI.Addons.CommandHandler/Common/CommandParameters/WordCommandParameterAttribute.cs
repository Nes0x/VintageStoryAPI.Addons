namespace VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;

public class WordCommandParameterAttribute : CommandParameterAttribute, IOptional
{
    public WordCommandParameterAttribute(string name, string[]? suggestions = null, bool isOptional = false)
    {
        Name = name;
        Suggestions = suggestions;
        IsOptional = isOptional;
    }

    
    public override string Name { get; }
    [ArgsParser] public string[]? Suggestions { get; }
    public override string MethodName => "Word";
    public string OptionalMethodName => "OptionalWord";
    public bool IsOptional { get; }
}