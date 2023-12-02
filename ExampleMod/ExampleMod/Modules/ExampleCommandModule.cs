using ExampleMod.PreConditions;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;

namespace ExampleMod.Modules;

public class ExampleCommandModule : CommandModule
{
    [Command<ICoreClientAPI>("hello-client")]
    [ExamplePreCondition<ICoreClientAPI>]
    public TextCommandResult HandleHelloClient(ICoreClientAPI api, [WordCommandParameter("word")] string word)
    {
        return TextCommandResult.Success($"Hello {Context.Caller.Player.PlayerName} from client. You typed {word}.");
    }

    [Command<ICoreServerAPI>("hello-server", Privilege = "chat")]
    public TextCommandResult HandleHelloServer(ICoreServerAPI api)
    {
        return TextCommandResult.Success($"Hello {Context.Caller.Player.PlayerName} from server.");
    }
}