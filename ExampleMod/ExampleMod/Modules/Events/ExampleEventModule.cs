using System;
using ExampleMod.Creators;
using Vintagestory.API.Client;
using VintageStoryAPI.Addons.EventHandler.Common;

namespace ExampleMod.Modules.Events;

public class ExampleEventModule : EventModule
{
    private readonly MessageCreator _messageCreator;

    public ExampleEventModule(MessageCreator messageCreator)
    {
        _messageCreator = messageCreator;
    }

    [Event<ICoreClientAPI>(EventType.PlayerDeath)]
    public void HandlePlayerDeath()
    {
        Console.WriteLine($"{_messageCreator.GetMessage()}");
    }
}