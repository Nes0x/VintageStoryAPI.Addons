using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

[AttributeUsage(AttributeTargets.Method)]
public class CommandAttribute<T> : Attribute where T : ICoreAPI
{
    internal bool? _requiredPlayer;

    public CommandAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public string? Description { get; init; }
    public string[]? Examples { get; init; }
    public string[]? Aliases { get; init; }
    public string? RootAlias { get; init; }
    public string? AdditionalInformation { get; init; }
    public string? Privilege { get; init; }

    public bool RequiredPlayer
    {
        get => _requiredPlayer.GetValueOrDefault();
        init => _requiredPlayer = value;
    }

}