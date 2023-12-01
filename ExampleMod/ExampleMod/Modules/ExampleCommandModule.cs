using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace ExampleMod.Modules;

public class ExampleCommandModule : CommandModule
{
    [Command<ICoreClientAPI>("hello-client")]
    public TextCommandResult HandleHelloClient(ICoreClientAPI api)
     {
         return TextCommandResult.Success($"Hello {Context.Caller.Player.PlayerName} from client.");
     }
    
    [Command<ICoreServerAPI>("hello-server", Privilege = "chat")]
    public TextCommandResult HandleHelloServer(ICoreServerAPI api)
    {
        return TextCommandResult.Success($"Hello {Context.Caller.Player.PlayerName} from server.");
    }
 }