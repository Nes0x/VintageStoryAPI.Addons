using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace ExampleMod.PreConditions;

public class ExamplePreConditionAttribute<T> : PreConditionAttribute<T> where T : ICoreAPI
{
    public override TextCommandResult Handle()
    {
        return Context.Caller.Player.PlayerName != "Nes0x"
            ? TextCommandResult.Error("Only Nes0x can call this command.")
            : TextCommandResult.Success();
    }
}