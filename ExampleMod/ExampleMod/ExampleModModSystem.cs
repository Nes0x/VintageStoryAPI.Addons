using System;
using System.Reflection;
using ExampleMod.Creators;
using ExampleMod.Modules.Events;
using Microsoft.Extensions.DependencyInjection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using VintageStoryAPI.Addons.CommandHandler;

namespace ExampleMod;

public class ExampleModModSystem : ModSystem
{
    public override void StartClientSide(ICoreClientAPI api)
    {
        IServiceProvider provider = new ServiceCollection().AddTransient<MessageCreator>().AddSingleton(_ => api).BuildServiceProvider();
        var commandHandler = new CommandHandler<ICoreClientAPI>(api);
        var eventHandler = new VintageStoryAPI.Addons.EventHandler.EventHandler<ICoreClientAPI>(provider);
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