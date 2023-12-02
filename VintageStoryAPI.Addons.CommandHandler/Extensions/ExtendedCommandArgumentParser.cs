using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Extensions;

public class ExtendedCommandArgumentParser : CommandArgumentParsers
{
    public ExtendedCommandArgumentParser(ICoreAPI api) : base(api)
    {
    }

    public static WordArgParser OptionalWord(string argName, string[] wordSuggestions)
    {
        return new WordArgParser(argName, false, wordSuggestions);
    }
}