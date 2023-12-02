using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler;

namespace ExampleMod;

public class ExampleModModSystem : ModSystem
{
    public override void StartClientSide(ICoreClientAPI api)
    {
        // api.ChatCommands.Create("bim")
        //     .HandleWith(_ => TextCommandResult.Success("bim"))
        //     .WithArgs(new WordArgParser("word", true))
        //     .BeginSubCommand("aha")
        //     .HandleWith(_ => TextCommandResult.Success("aha"))
        //     .EndSubCommand()
        //     .BeginSubCommand("no")
        //     .WithPreCondition(_ => TextCommandResult.Success("błąd"))
        //     .WithPreCondition(_ => TextCommandResult.Error("błont"))
        //     .HandleWith(_ => TextCommandResult.Success("no"));
        var commandHandler = new CommandHandler<ICoreClientAPI>(api);
        commandHandler.RegisterCommands();
    }

    // public override void StartServerSide(ICoreServerAPI api)
    // {
    //     var commandHandler = new CommandHandler<ICoreServerAPI>(api);
    //     commandHandler.RegisterCommands();
    // }
}