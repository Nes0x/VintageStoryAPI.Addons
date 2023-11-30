using System;
using ExampleMod.Creators;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Parsers.CommandParameters;

namespace ExampleMod.Modules;

public class ExampleCommandModule : CommandModule
{
    private readonly MessageCreator _messageCreator;

    public ExampleCommandModule(MessageCreator messageCreator)
    {
        _messageCreator = messageCreator;
    }

    [Command("hello", Description = "Example")]
    public TextCommandResult HandleHello([IntCommandParameter("number", isOptional: true)] int number)
    {
        return TextCommandResult.Success(_messageCreator.GetMessage() + $" {Context.Caller.Player.PlayerName} {number}");
    }
}