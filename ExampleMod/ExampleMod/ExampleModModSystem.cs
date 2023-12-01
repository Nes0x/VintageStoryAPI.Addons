using System;
using ExampleMod.Creators;
using Microsoft.Extensions.DependencyInjection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using VintageStoryAPI.Addons.CommandHandler;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace ExampleMod;

public class ExampleModModSystem : ModSystem
{
    public override void StartClientSide(ICoreClientAPI api)
    {
        var commandHandler = new CommandHandler<ICoreClientAPI>(api);
        commandHandler.RegisterCommands();
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        var commandHandler = new CommandHandler<ICoreServerAPI>(api);
        commandHandler.RegisterCommands();
    }

}