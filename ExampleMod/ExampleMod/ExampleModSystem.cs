using System.Reflection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using VintageStoryAPI.Addons.CommandHandler;
using VintageStoryAPI.Addons.EventHandler;

namespace ExampleMod;

public class ExampleModSystem : ModSystem
{
    public override void StartClientSide(ICoreClientAPI api)
    {
        var commandsRegister = new CommandsRegister<ICoreClientAPI>(api);
        var eventsRegister = new EventsRegister<ICoreClientAPI>(api);
        var assembly = Assembly.GetExecutingAssembly();
        commandsRegister.RegisterAll(assembly);
        eventsRegister.RegisterAll(assembly);
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        var commandsRegister = new CommandsRegister<ICoreServerAPI>(api);
        commandsRegister.RegisterAll(Assembly.GetExecutingAssembly());
    }
}