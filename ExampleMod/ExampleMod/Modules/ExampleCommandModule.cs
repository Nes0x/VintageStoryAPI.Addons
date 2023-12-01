using ExampleMod.Creators;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace ExampleMod.Modules;

public class ExampleCommandModule : CommandModule
{
    private readonly MessageCreator _messageCreator;

    public ExampleCommandModule(MessageCreator messageCreator)
    {
        _messageCreator = messageCreator;
    }

    [Command<ICoreClientAPI>("hello", Description = "Example")]
    public TextCommandResult HandleHello()
    {
        return TextCommandResult.Success(_messageCreator.GetMessage() + $" {Context.Caller.Player.PlayerName}");
    }
}