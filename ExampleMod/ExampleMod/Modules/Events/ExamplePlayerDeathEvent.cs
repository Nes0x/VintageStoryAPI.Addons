using Vintagestory.API.Client;
using VintageStoryAPI.Addons.EventHandler.Common.Events;

namespace ExampleMod.Modules.Events;

public class ExamplePlayerDeathEvent : PlayerDeathEvent<ICoreClientAPI>
{
    public ExamplePlayerDeathEvent(ICoreClientAPI api) : base(api)
    {
 
    }

    public override void Handle(IClientPlayer player)
    {
        player.ShowChatNotification("test");
    }
}