using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

internal class CommandProperties
{
    public bool? RequiredPlayer { get; init; }
    public string? Privilege { get; init; }
    public string? RootAlias { get; init; }
    public string? AdditionalInformation { get; init; }
    public string? Description { get; init; }
    public string[]? Examples { get; init; }
    public string[]? Aliases { get; init; }
    public ICommandArgumentParser[]? CommandParameters { get; init; }
    public MethodInfo? PreConditionMethod { get; init; }
}