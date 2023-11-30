using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

internal class Command
{
    public Command(string name, MethodInfo commandMethod, Type type)
    {
        Name = name;
        CommandMethod = commandMethod;
        Type = type;
    }

    public string Name { get; init; }
    public MethodInfo CommandMethod { get; init; }
    public Type Type { get; init; }
    public string? Description { get; init; }
    public string[]? Examples { get; init; }
    public string[]? Aliases { get; init; }
    public ICommandArgumentParser[]? CommandArguments { get; init; }
    public string? RootAlias { get; init; }
    public string? AdditionalInformation { get; init; }
    public MethodInfo? PreConditionMethod { get; init; }
    public bool? RequiredPlayer { get; init; }
    public string? Privilege { get; init; }
}