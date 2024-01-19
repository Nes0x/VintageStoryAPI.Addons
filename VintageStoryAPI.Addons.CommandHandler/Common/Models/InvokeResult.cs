using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Common.Models;

internal class InvokeResult
{
    public TextCommandResult? Result { get; init; }
    public bool IsError { get; init; }
    public string? ErrorMessage { get; init; }
}