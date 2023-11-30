namespace VintageStoryAPI.Addons.CommandHandler.Parsers.CommandParameters;

public interface IOptional
{
    string OptionalMethodName { get; }
    bool IsOptional { get; }
}