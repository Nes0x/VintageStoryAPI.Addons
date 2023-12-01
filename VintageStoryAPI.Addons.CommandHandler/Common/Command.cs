using System.Reflection;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

internal class Command<T> where T : ICoreAPI
{
    public Command(string name, MethodInfo commandMethod, Type type)
    {
        Name = name;
        CommandMethod = commandMethod;
        Type = type;
    }

    public string Name { get; }
    public MethodInfo CommandMethod { get; }
    public Type Type { get; }
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