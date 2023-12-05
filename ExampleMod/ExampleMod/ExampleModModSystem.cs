using System;
using System.Reflection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using VintageStoryAPI.Addons.CommandHandler;
using VintageStoryAPI.Addons.EventHandler;

namespace ExampleMod;

public class ExampleModModSystem : ModSystem
{
    public override void StartClientSide(ICoreClientAPI api)
    {
        var commandHandler = new CommandHandler<ICoreClientAPI>(api);
        // var eventHandler = new VintageStoryAPI.Addons.EventHandler.EventHandler<ICoreClientAPI>();
        var assembly = Assembly.GetExecutingAssembly();
        commandHandler.RegisterAll(assembly);
        // eventHandler.RegisterAll(assembly);
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        var commandHandler = new CommandHandler<ICoreServerAPI>(api);
        commandHandler.RegisterAll(Assembly.GetExecutingAssembly());
    }
}