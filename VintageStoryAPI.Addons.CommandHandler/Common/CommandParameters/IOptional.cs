namespace VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;

public interface IOptional
{
    string OptionalMethodName { get; }
    bool IsOptional { get; }
}