using System;
using System.ComponentModel.Design;
using System.Reflection;
using ExampleMod.Creators;
using Microsoft.Extensions.DependencyInjection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using VintageStoryAPI.Addons.CommandHandler;
using VintageStoryAPI.Addons.EventHandler;

namespace ExampleMod;

public class ExampleModModSystem : ModSystem
{
    public override void StartClientSide(ICoreClientAPI api)
    {
        IServiceProvider provider = new ServiceCollection().AddTransient<MessageCreator>().BuildServiceProvider();
        var commandHandler = new CommandHandler<ICoreClientAPI>(api);
        var eventHandler = new VintageStoryAPI.Addons.EventHandler.EventHandler<ICoreClientAPI>(api, provider);
        var assembly = Assembly.GetExecutingAssembly();
        commandHandler.RegisterAll(assembly);
        eventHandler.RegisterAll(assembly);
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        var commandHandler = new CommandHandler<ICoreServerAPI>(api);
        commandHandler.RegisterAll(Assembly.GetExecutingAssembly());
    }
}